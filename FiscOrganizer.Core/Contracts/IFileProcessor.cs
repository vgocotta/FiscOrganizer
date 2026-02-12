using FiscOrganizer.Core.Models;

namespace FiscOrganizer.Core.Contracts;

public interface IFileProcessor
{
    int Code { get; }
    ProcessedFileModel Process(FileInfo fileInfo, string firstLine);
}
