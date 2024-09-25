using branef.Domain.Enums;

namespace branef.Domain.Models;

public class Empresa : Entity
{
    public string Nome { get; set; } = string.Empty;
    public PorteEmpresa Porte { get; set; }
}