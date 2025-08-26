using FiscOrganizer.Comparers;
using FiscOrganizer.Contracts;
using FiscOrganizer.CustomEventArgs;
using FiscOrganizer.Enums;
using FiscOrganizer.Extentions;
using FiscOrganizer.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace FiscOrganizer.Services;

/// <summary>
/// Provides services for organizing SPED files, including moving, renaming, and logging file operations.
/// </summary>
public class OrganizeService : IOrganizeService
{
    /// <summary>
    /// Occurs when a file is processed.
    /// </summary>
    public event EventHandler<EventArgs>? ProcessFile;
    /// <summary>
    /// Occurs when a log event is generated.
    /// </summary>
    public event EventHandler<LogEventArgs>? LogEvent;

    private bool _revertProcess = false;
    private readonly IFileRecognizerService _fileRecognizerService;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrganizeService"/> class.
    /// </summary>
    /// <param name="fileRecognizerService">Service for recognizing SPED files.</param>
    public OrganizeService(IFileRecognizerService fileRecognizerService)
    {
        _fileRecognizerService = fileRecognizerService;
    }

    /// <summary>
    /// Gets or sets the logs generated during file organization.
    /// </summary>
    public List<string> Logs { get; set; } = [];

    /// <summary>
    /// Processes and organizes files according to the specified model and cancellation token.
    /// </summary>
    /// <param name="organize">The organization model containing settings and file items.</param>
    /// <param name="cancellationTokenSource">Token source for cancellation.</param>
    public async Task ProcessAsync(OrganizeModel organize, CancellationTokenSource cancellationTokenSource)
    {
        Logs.Clear();

        var processedFiles = await _fileRecognizerService.RecognizeFiles(organize.FileItems, cancellationTokenSource);

        ProcessUnidentifiedFiles(processedFiles, organize, cancellationTokenSource);

        var identifiedFiles = processedFiles.Where(c => c.SpedFileType != SpedFileType.NaoIdentificado);

        var mainFolders = identifiedFiles
            .OrderByDescending(o => o.SpedFileType)
            .ThenBy(t => t.Cnpj)
            .ThenByDescending(t => t.DataFinal)
            .Distinct(new ProcessedFileModelCnpjBaseComparer())
            .ToDictionary(k => k.CnpjBase!, e => $"{Regex.Replace(e.RazaoSocial!, @"[\\/:*?""<>|]", "")} - {e.Cnpj}");

        var groupedFiles = identifiedFiles
            .GroupBy(c => new { c.SpedFileType, c.Cnpj, c.DataInicial })
            .ToDictionary(g => g.Key, g => g.OrderBy(c => c.Cnpj).ThenBy(c => c.DataInicial).ThenByDescending(c => c.DataEntrega).ToList());

        foreach (var group in groupedFiles)
        {
            string mainDirectory = Path.Combine(organize.DestinyFolder!, mainFolders[group.Key.Cnpj![..8]]);

            bool firstFile = true;
            int occurrence = 1;
            foreach (var file in group.Value)
            {
                StringBuilder log = new();

                if (cancellationTokenSource.IsCancellationRequested) break;

                string _oldFullFilePath = file.FileInfo!.FullName;
                log.AppendLine($"Processando arquivo: {_oldFullFilePath}");

                string newFileDirectory = Path.Combine(mainDirectory, file.SpecificFileFolder!);
                if (organize.SeparateOriginals && !firstFile && file.DataEntrega.HasValue)
                {
                    newFileDirectory = Path.Combine(newFileDirectory, "RETIFICADOS");
                }

                if (!Directory.Exists(newFileDirectory))
                {
                    Directory.CreateDirectory(newFileDirectory);
                    OnLogEvent(new LogEventArgs($"Diretório criado: {newFileDirectory}"));
                    Logs.Add($"Diretório criado: {newFileDirectory}");
                }
                log.AppendLine($"   Pasta de destino:{newFileDirectory}");

                if (file.HasReceipt)
                {
                    var receiptFile = new FileInfo(Path.ChangeExtension(file.FileInfo!.FullName, ".rec"));
                    log.AppendLine($"   Identificado arquivo de recibo:{receiptFile.Name}");

                    string newFullReceiptFilePath = Path.Combine(newFileDirectory, receiptFile.Name);
                    log.AppendLine($"   Novo caminho do arquivo de recibo:{newFullReceiptFilePath}");

                    try
                    {
                        receiptFile.MoveTo(newFullReceiptFilePath, false);
                        log.AppendLine("   Arquivo de recibo movido");
                    }
                    catch (Exception ex)
                    {
                        log.AppendLine("   Erro ao mover arquivo");
                        log.AppendLine($"   Mantido em: {_oldFullFilePath}");
                        log.Append($"   Mensagem de erro:{ex.Message}");
                    }
                }

                string fileName = file.FileInfo!.Name;
                if (organize.ChangeFileName)
                {
                    fileName = BuildNewFileName(file, occurrence);
                }
                string newFullFilePath = Path.Combine(newFileDirectory, fileName);

                try
                {
                    file.FileInfo.MoveTo(newFullFilePath);
                    log.AppendLine("   Arquivo movido");
                }
                catch (Exception ex)
                {
                    log.AppendLine("   Erro ao mover arquivo");
                    log.AppendLine($"   Mantido em: {_oldFullFilePath}");
                    log.Append($"   Mensagem de erro:{ex.Message}");
                }
                OnLogEvent(new LogEventArgs(log.ToString()));
                Logs.Add(log.ToString());
                firstFile = false;
                occurrence++;
            }
        }
    }

    /// <summary>
    /// Builds a new file name for the processed file based on its properties and occurrence.
    /// </summary>
    /// <param name="fileModel">The processed file model.</param>
    /// <param name="fileOccurrence">The occurrence number of the file.</param>
    /// <returns>The new file name.</returns>
    private static string BuildNewFileName(ProcessedFileModel fileModel, int fileOccurrence)
    {
        string fileType = fileModel.SpedFileType.GetDescription();
        string fileFinality = fileModel.SpedFileFinality.GetDescription();
        return $"{fileType} - {fileModel.Cnpj} - {fileModel.DataInicial:yyyyMMdd} - {fileModel.DataFinal:yyyyMMdd} - {fileFinality} - {fileOccurrence}.txt";
    }

    /// <summary>
    /// Processes files that could not be identified as SPED files.
    /// </summary>
    /// <param name="files">The collection of processed files.</param>
    /// <param name="organize">The organization model.</param>
    /// <param name="cancellationTokenSource">Token source for cancellation.</param>
    private void ProcessUnidentifiedFiles(IEnumerable<ProcessedFileModel> files, OrganizeModel organize, CancellationTokenSource cancellationTokenSource)
    {
        StringBuilder log = new();
        string specificFolder = SpedFileType.NaoIdentificado.GetDescription();
        string unidentifiedFolder = Path.Combine(organize.DestinyFolder!, specificFolder);
        if (organize.MoveNotIdentified && !Directory.Exists(unidentifiedFolder))
        {
            Directory.CreateDirectory(unidentifiedFolder);
            OnLogEvent(new LogEventArgs($"Diretório criado: {unidentifiedFolder}"));
            Logs.Add($"Diretório criado: {unidentifiedFolder}");
        }
        foreach (var file in files.Where(c => c.SpedFileType == SpedFileType.NaoIdentificado))
        {
            if (cancellationTokenSource.IsCancellationRequested) break;
            string oldFullFilePath = file.FileInfo!.FullName;
            log.AppendLine($"Arquivo: {oldFullFilePath}");
            log.AppendLine("   Não identificado como arquivo SPED");
            if (!organize.MoveNotIdentified)
            {
                log.AppendLine($"   Mantido em: {oldFullFilePath}");
                continue;
            }
            string fileName = file.FileInfo!.Name;
            log.AppendLine($"   Nome no destino:{fileName}");
            log.AppendLine($"   Pasta de destino:{unidentifiedFolder}");
            string newFullFilePath = Path.Combine(unidentifiedFolder, fileName);
            try
            {
                file.FileInfo?.MoveTo(newFullFilePath);
                log.AppendLine("   Arquivo movido");
            }
            catch (Exception ex)
            {
                log.AppendLine("   Erro ao mover arquivo");
                log.AppendLine($"   Mantido em: {oldFullFilePath}");
                log.Append($"   Mensagem de erro:{ex.Message}");
            }
        }
        Logs.Add(log.ToString());
    }

    /// <summary>
    /// Raises the <see cref="ProcessFile"/> event.
    /// </summary>
    /// <param name="e">Event arguments.</param>
    protected virtual void OnFileProcess(EventArgs e)
    {
        ProcessFile?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="LogEvent"/> event.
    /// </summary>
    /// <param name="e">Log event arguments.</param>
    protected virtual void OnLogEvent(LogEventArgs e)
    {
        LogEvent?.Invoke(this, e);
    }

    /// <summary>
    /// Cancels the organization process, optionally reverting changes.
    /// </summary>
    /// <param name="revert">If true, revert the process.</param>
    public void Cancel(bool revert = false)
    {
        _revertProcess = revert;
    }
}
