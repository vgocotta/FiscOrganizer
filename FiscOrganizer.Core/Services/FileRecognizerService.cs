using FiscOrganizer.Core.Contracts;
using FiscOrganizer.Core.Enums;
using FiscOrganizer.Core.Extentions;
using FiscOrganizer.Core.Models;

namespace FiscOrganizer.Core.Services;

public class FileRecognizerService(IEnumerable<IFileProcessor> processors) : IFileRecognizerService
{
    private readonly Dictionary<int, IFileProcessor> _map = processors.ToDictionary(p => p.Code);

    public async Task<ICollection<ProcessedFileModel>> RecognizeFiles(IEnumerable<FileItem> fileItems, CancellationTokenSource cancellationTokenSource)
    {
        List<ProcessedFileModel> processedFiles = [];
        foreach (var fileItem in fileItems)
        {
            if (cancellationTokenSource.IsCancellationRequested) break;

            FileInfo fileInfo = new(fileItem.FullPath);
            string? firstLine = await ReadFirstLineAsync(fileInfo);
            if (string.IsNullOrWhiteSpace(firstLine) || firstLine[0] != '|')
            {
                processedFiles.Add(new ProcessedFileModel(SpedFileType.NaoIdentificado, fileInfo));
                continue;
            }

            int cnpjIndex = firstLine.GetIndexFirstCnpj();

            if (_map.TryGetValue(cnpjIndex, out var proc))
            {
                processedFiles.Add(proc.Process(fileInfo, firstLine));
                continue;
            }

            processedFiles.Add(new ProcessedFileModel(SpedFileType.NaoIdentificado, fileInfo));
            continue;
        }
        return processedFiles;
    }
    private static async Task<string?> ReadFirstLineAsync(FileInfo fileInfo)
    {
        using StreamReader reader = new(fileInfo.FullName);
        return await reader.ReadLineAsync();
    }
}
