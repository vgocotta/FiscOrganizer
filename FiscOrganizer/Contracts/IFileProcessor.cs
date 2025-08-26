using FiscOrganizer.Models;

namespace FiscOrganizer.Contracts;

public interface IFileProcessor
{
    int Code { get; }
    ProcessedFileModel Process(FileInfo fileInfo, string firstLine);
}
