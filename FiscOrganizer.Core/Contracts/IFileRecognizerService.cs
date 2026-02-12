using FiscOrganizer.Core.Models;

namespace FiscOrganizer.Core.Contracts;

public interface IFileRecognizerService
{
    Task<ICollection<ProcessedFileModel>> RecognizeFiles(IEnumerable<FileItem> fileItems, CancellationTokenSource cancellationTokenSource);
}