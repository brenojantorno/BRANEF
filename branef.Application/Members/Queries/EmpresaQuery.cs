using branef.Application.Dtos;
using MediatR;

namespace branef.Application.Members.Queries;

public class EmpresaQuery : IRequest<IEnumerable<EmpresaDto>>
{

}