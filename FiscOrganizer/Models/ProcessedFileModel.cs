using FiscOrganizer.Enums;
using System.Text;

namespace FiscOrganizer.Models;

public class ProcessedFileModel
{
    public ProcessedFileModel(SpedFileType spedFileType, FileInfo? fileInfo)
    {
        SpedFileType = spedFileType;
        FileInfo = fileInfo;
    }

    public ProcessedFileModel(SpedFileType spedFileType, FileInfo? fileInfo, string? cnpj, string? razaoSocial, DateTime? dataInicial, DateTime? dataFinal, SpedFileFinality spedFileFinality, bool hasReceipt, DateTime? dataEntrega, string? specificFileFolder)
    {
        SpedFileType = spedFileType;
        FileInfo = fileInfo;
        Cnpj = cnpj;
        RazaoSocial = razaoSocial;
        DataInicial = dataInicial;
        DataFinal = dataFinal;
        SpedFileFinality = spedFileFinality;
        HasReceipt = hasReceipt;
        DataEntrega = dataEntrega;
        SpecificFileFolder = specificFileFolder;
    }

    public SpedFileType SpedFileType { get; private set; }
    public FileInfo? FileInfo { get; private set; }
    public string? Cnpj { get; private set; }
    public string? CnpjBase => Cnpj?[..8];
    public string? RazaoSocial { get; private set; }
    public DateTime? DataInicial { get; private set; }
    public DateTime? DataFinal { get; private set; }
    public SpedFileFinality SpedFileFinality { get; private set; }
    public bool HasReceipt { get; private set; }
    public DateTime? DataEntrega { get; private set; }
    public string? SpecificFileFolder { get; private set; }
    
}
