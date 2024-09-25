using branef.Application.Dtos;
using MediatR;

namespace branef.Application.Members.Queries;

public class EmpresaIdQuery(Guid id) : IRequest<EmpresaDto>
{
    public Guid Id { get; set; } = id;
}