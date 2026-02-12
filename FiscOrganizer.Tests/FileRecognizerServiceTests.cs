using FiscOrganizer.Core.Contracts;
using FiscOrganizer.Core.Enums;
using FiscOrganizer.Core.Models;
using FiscOrganizer.Core.Services;
using Moq;

namespace FiscOrganizer.Tests;

public class FileRecognizerServiceTests
{
    [Fact]
    public async Task Should_ReturnProcessedFile_When_ProcessorExists()
    {
        // 1. ARRANGE
        string spedContent = "|0000|006|0|||01122025|31122025|COMPANY NAME TEST|92680799000122|ZZ|9999999||00|2|";
        string tempFilePath = Path.GetTempFileName();
        await File.WriteAllTextAsync(tempFilePath, spedContent);

        // Mock setup
        int expectedIndex = 9; // Assume logic returns 2 for this content
        var processorMock = new Mock<IFileProcessor>();
        processorMock.Setup(p => p.Code).Returns(expectedIndex);

        // Expected result setup
        var expectedResult = new ProcessedFileModel(SpedFileType.EfdContribuicoes, new FileInfo(tempFilePath));

        processorMock
            .Setup(p => p.Process(It.IsAny<FileInfo>(), It.IsAny<string>()))
            .Returns(expectedResult);

        // Service injection
        var service = new FileRecognizerService([processorMock.Object]);
        var itemsToProcess = new List<FileItem>
            {
                new FileItem { FullPath = tempFilePath }
            };

        // 2. ACT
        try
        {
            // NOTE: Depends on your static extension logic returning the same code as the mock
            var result = await service.RecognizeFiles(itemsToProcess, new CancellationTokenSource());

            // 3. ASSERT
            Assert.Single(result);
            Assert.Equal(SpedFileType.EfdContribuicoes, result.First().SpedFileType);
        }
        finally
        {
            if (File.Exists(tempFilePath))
                File.Delete(tempFilePath);
        }
    }

    [Fact]
    public async Task Should_ReturnUnidentified_When_FileHeaderIsInvalid()
    {
        // ARRANGE
        string invalidContent = "INVALID CONTENT WITHOUT PIPE";
        string tempFilePath = Path.GetTempFileName();
        await File.WriteAllTextAsync(tempFilePath, invalidContent);

        // No processors needed
        var service = new FileRecognizerService([]);
        var items = new List<FileItem> { new() { FullPath = tempFilePath } };

        // ACT
        try
        {
            var result = await service.RecognizeFiles(items, new CancellationTokenSource());

            // ASSERT
            Assert.Equal(SpedFileType.NaoIdentificado, result.First().SpedFileType);
        }
        finally
        {
            File.Delete(tempFilePath);
        }
    }
}
