using FiscOrganizer.Core.Contracts;
using FiscOrganizer.Core.Enums;
using FiscOrganizer.Core.Extentions;
using FiscOrganizer.Core.Models;

namespace FiscOrganizer.Core.Services;

public sealed class EcfFileProcessor : IFileProcessor
{
    public int Code => 4;

    public ProcessedFileModel Process(FileInfo fileInfo, string firstLine)
    {
        var fileFinality = SpedFileFinality.Original;
        if (firstLine.GetSpedField(12) == "S")
        {
            fileFinality = SpedFileFinality.Retificadora;
        }
        string specificFileFolder = SpedFileType.Ecf.GetDescription();

        return new ProcessedFileModel(
            SpedFileType.Ecf,
            fileInfo,
            firstLine.GetSpedField(4),
            firstLine.GetSpedField(5),
            firstLine.GetSpedFieldDateTime(10),
            firstLine.GetSpedFieldDateTime(11),
            fileFinality,
            false,
            null,
            specificFileFolder
        );
    }
}
