using branef.Application.Members.Notifications;
using branef.Domain.Interfaces.Repositories;
using branef.Domain.Models;
using branef.Domain.Enums;
using MediatR;

namespace branef.Application.Handlers.Notifications;

public class EmpresaNotificationHandler(IQueryRepository<Empresa> empresaRepostory) : INotificationHandler<EmpresaNotification>
{
    public async Task Handle(EmpresaNotification notification, CancellationToken cancellationToken)
    {
        switch (notification.ActionType)
        {
            case ActionType.Update:
                await empresaRepostory.Update(notification.Empresa, cancellationToken);
                break;
            case ActionType.Delete:
                await empresaRepostory.Delete(notification.Empresa, cancellationToken);
                break;
            default:
                await empresaRepostory.Create(notification.Empresa, cancellationToken);
                break;
        }
    }
}