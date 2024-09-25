using System.ComponentModel;

namespace branef.Domain.Enums;
public enum PorteEmpresa
{
    [Description("Pequena")]
    Pequena = 1,
    [Description("Média")]
    Media = 2,
    [Description("Grande")]
    Grande = 3
}