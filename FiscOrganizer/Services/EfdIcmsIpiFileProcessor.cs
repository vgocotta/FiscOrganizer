using FiscOrganizer.Contracts;
using FiscOrganizer.Enums;
using FiscOrganizer.Extentions;
using FiscOrganizer.Models;

namespace FiscOrganizer.Services;

public sealed class EfdIcmsIpiFileProcessor : IFileProcessor
{
    public int Code => 7;

    public ProcessedFileModel Process(FileInfo fileInfo, string firstLine)
    {
        string cnpj = firstLine.GetSpedField(7);
        var fileFinality = SpedFileFinality.Original;
        if (firstLine.GetSpedFieldInt(3) == 1)
        {
            fileFinality = SpedFileFinality.Retificadora;
        }
        string specificFileFolder = Path.Combine(SpedFileType.EfdIcmsIpi.GetDescription(), cnpj);

        return new ProcessedFileModel(
            SpedFileType.EfdIcmsIpi,
            fileInfo,
            cnpj,
            firstLine.GetSpedField(6),
            firstLine.GetSpedFieldDateTime(4),
            firstLine.GetSpedFieldDateTime(5),
            fileFinality,
            false,
            null,
            specificFileFolder
        );
    }
}
