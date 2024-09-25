using MediatR;
using branef.Application.Dtos;
using branef.Application.Members.Queries;
using branef.Domain.Extensions;
using branef.Domain.Interfaces.Repositories;
using branef.Domain.Models;

namespace branef.Application.Handlers.Queries;

public class EmpresaQueryHandler(IQueryRepository<Empresa> empresaRepostory) : IRequestHandler<EmpresaQuery, IEnumerable<EmpresaDto>>, IRequestHandler<EmpresaIdQuery, EmpresaDto>
{
    public async Task<IEnumerable<EmpresaDto>> Handle(EmpresaQuery query, CancellationToken cancellationToken)
    {
        var empresas = await empresaRepostory.GetAll(cancellationToken);

        if (empresas == null || empresas.Count == 0)
            return [];

        return empresas.Select(emp => new EmpresaDto
        {
            Id = emp.Id,
            Nome = emp.Nome,
            Porte = emp.Porte,
            PorteDescricao = emp.Porte.GetDescription(),
        });
    }

    public async Task<EmpresaDto> Handle(EmpresaIdQuery query, CancellationToken cancellationToken)
    {
        var empresa = await empresaRepostory.FindAsync(query.Id, cancellationToken);
        var dto = new EmpresaDto();

        if (empresa != null)
        {
            dto.Id = empresa.Id;
            dto.Nome = empresa.Nome;
            dto.Porte = empresa.Porte;
            dto.PorteDescricao = empresa.Porte.GetDescription();
        }

        return dto;
    }
}