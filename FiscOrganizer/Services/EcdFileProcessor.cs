using FiscOrganizer.Contracts;
using FiscOrganizer.Enums;
using FiscOrganizer.Extentions;
using FiscOrganizer.Models;

namespace FiscOrganizer.Services;

public sealed class EcdFileProcessor : IFileProcessor
{
    public int Code => 6;

    public ProcessedFileModel Process(FileInfo fileInfo, string firstLine)
    {
        var fileFinality = SpedFileFinality.Original;
        if (firstLine.GetSpedFieldInt(14) == 1)
        {
            fileFinality = SpedFileFinality.Retificadora;
        }
        string specificFileFolder = SpedFileType.Ecd.GetDescription();

        return new ProcessedFileModel(
            SpedFileType.Ecd,
            fileInfo,
            firstLine.GetSpedField(6),
            firstLine.GetSpedField(5),
            firstLine.GetSpedFieldDateTime(3),
            firstLine.GetSpedFieldDateTime(4),
            fileFinality,
            false,
            null,
            specificFileFolder
        );
    }
}
