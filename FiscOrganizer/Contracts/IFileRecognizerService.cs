using FiscOrganizer.Models;

namespace FiscOrganizer.Contracts;

public interface IFileRecognizerService
{
    Task<ICollection<ProcessedFileModel>> RecognizeFiles(IEnumerable<FileItem> fileItems, CancellationTokenSource cancellationTokenSource);
}