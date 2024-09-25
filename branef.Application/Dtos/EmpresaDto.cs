using branef.Domain.Enums;

namespace branef.Application.Dtos;

public class EmpresaDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public PorteEmpresa Porte { get; set; }
    public string PorteDescricao { get; set; } = string.Empty;
}