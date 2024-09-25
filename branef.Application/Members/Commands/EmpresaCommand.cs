using branef.Application.Dtos;
using branef.Domain.Enums;
using branef.Domain.Interfaces;
using MediatR;

namespace branef.Application.Members.Commands;

public class EmpresaCommand : IRequest<IResult<EmpresaDto>>
{
    public string Nome { get; set; } = string.Empty;
    public PorteEmpresa? Porte { get; set; }
}