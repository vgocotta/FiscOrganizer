using FiscOrganizer.Contracts;
using FiscOrganizer.Enums;
using FiscOrganizer.Extentions;
using FiscOrganizer.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FiscOrganizer.Services;

public sealed class EfdContribuicoesFileProcessor : IFileProcessor
{
    public int Code => 9;

    public ProcessedFileModel Process(FileInfo fileInfo, string firstLine)
    {
        var fileFinality = SpedFileFinality.Original;
        if (firstLine.GetSpedFieldInt(3) == 1)
        {
            fileFinality = SpedFileFinality.Retificadora;
        }

        string receiptName = Path.ChangeExtension(fileInfo!.FullName, ".rec");
        bool hasReceipt = File.Exists(receiptName);

        DateTime? dataEntrega = GetDataEntregaOrNull(fileInfo.Name);
        string specificFileFolder = SpedFileType.EfdContribuicoes.GetDescription();

        return new ProcessedFileModel(
            SpedFileType.EfdContribuicoes,
            fileInfo,
            firstLine.GetSpedField(9),
            firstLine.GetSpedField(8),
            firstLine.GetSpedFieldDateTime(6),
            firstLine.GetSpedFieldDateTime(7),
            fileFinality,
            hasReceipt,
            dataEntrega,
            specificFileFolder
        );
    }
    private static readonly Regex NomePadraoRegex = new(@"^[A-Z]+_(\d{8})_(\d{8})_(\d{14})_(?:Retificadora|Original)_(\d{14})_[A-F0-9]+\.txt$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

    public static DateTime? GetDataEntregaOrNull(string pathOrFileName)
    {
        if (string.IsNullOrWhiteSpace(pathOrFileName))
            return null;

        var name = Path.GetFileName(pathOrFileName);

        var m = NomePadraoRegex.Match(name);
        if (!m.Success)
            return null;

        var stamp = m.Groups[4].Value; // AAAAMMDDhhmmss

        if (DateTime.TryParseExact(stamp, "yyyyMMddHHmmss",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.AssumeLocal, // ajuste para AssumeLocal se preferir
                                   out var dt))
        {
            return dt;
        }

        return null;
    }
}
