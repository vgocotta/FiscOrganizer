using System.ComponentModel;

namespace FiscOrganizer.Core.Enums;

public enum SpedFileType
{
    [Description("EFD ICMS IPI")]
    EfdIcmsIpi = 0,
    [Description("EFD CONTRIBUIÇÕES")]
    EfdContribuicoes = 1,
    [Description("ECD")]
    Ecd = 2,
    [Description("ECF")]
    Ecf = 3,
    [Description("ERROS")]
    NaoIdentificado = 9,
}
