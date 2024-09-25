using MediatR;
using branef.Application.Dtos;
using branef.Domain.Interfaces;

namespace branef.Application.Members.Commands;

public class DeleteEmpresaCommand(Guid id) : IRequest<IResult<EmpresaDto>>
{
    public Guid Id { get; set; } = id;
}