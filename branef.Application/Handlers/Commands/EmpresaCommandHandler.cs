using branef.Application.Dtos;
using branef.Application.Members.Commands;
using branef.Application.Members.Notifications;
using branef.Domain.Extensions;
using branef.Domain.Interfaces;
using branef.Domain.Interfaces.Repositories;
using branef.Domain.Models;
using branef.Domain.Enums;
using MediatR;

namespace branef.Application.Handlers.Commands;

public class EmpresaCommandHandler(IUnitOfWork _context, IMediator _mediator, IRepository<Empresa> _empresaRepository) : IRequestHandler<EmpresaCommand, IResult<EmpresaDto>>, IRequestHandler<UpdateEmpresaCommand, IResult<EmpresaDto>>, IRequestHandler<DeleteEmpresaCommand, IResult<EmpresaDto>>
{
    /// <summary>
    /// Handle de criação
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IResult<EmpresaDto>> Handle(EmpresaCommand command, CancellationToken cancellationToken)
    {
        var validateResult = Validate(command);

        if (validateResult != null)
            return validateResult;

        var model = new Empresa
        {
            Nome = command.Nome,
            Porte = command.Porte.Value
        };

        _empresaRepository.Create(model, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new EmpresaNotification(model, ActionType.Create), cancellationToken);

        return new Result<EmpresaDto>(new EmpresaDto
        {
            Id = model.Id,
            Nome = model.Nome,
            Porte = model.Porte,
            PorteDescricao = model.Porte.GetDescription(),
        });
    }
    public async Task<IResult<EmpresaDto>> Handle(UpdateEmpresaCommand command, CancellationToken cancellationToken)
    {
        var validateResult = Validate(command);

        if (validateResult != null)
            return validateResult;

        if (command.Id.Equals(Guid.Empty))
            return new Result<EmpresaDto>("Id", BusinessMessage.MSG03);

        var model = await _empresaRepository.FindAsync(command.Id, cancellationToken);

        if (model == null)
            return new Result<EmpresaDto>("Empresa não encontrada.");

        model.Nome = command.Nome;
        model.Porte = command.Porte.Value;

        _empresaRepository.Update(model);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new EmpresaNotification(model, ActionType.Update), cancellationToken);

        return new Result<EmpresaDto>(new EmpresaDto
        {
            Id = model.Id,
            Nome = model.Nome,
            Porte = model.Porte,
            PorteDescricao = model.Porte.GetDescription(),
        });
    }

    public async Task<IResult<EmpresaDto>> Handle(DeleteEmpresaCommand command, CancellationToken cancellationToken)
    {

        if (command.Id.Equals(Guid.Empty))
            return new Result<EmpresaDto>("Id", "O campo 'Id' deve ser fornecido.");

        var model = await _empresaRepository.FindAsync(command.Id, cancellationToken);

        if (model == null)
            return new Result<EmpresaDto>("Empresa não encontrada.");

        _empresaRepository.Delete(model);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new EmpresaNotification(model, ActionType.Delete), cancellationToken);

        return new Result<EmpresaDto>(new EmpresaDto());
    }

    public static IResult<EmpresaDto>? Validate(EmpresaCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Nome))
            return new Result<EmpresaDto>("Nome", "O campo 'Nome' deve ser preenchido.");

        if (command.Nome.Length > 500)
            return new Result<EmpresaDto>("Nome", "O campo 'Nome' deve ser menor ou igual a 500 caracteres.");

        return null;
    }
}