using MediatR;
using branef.Domain.Enums;
using branef.Domain.Models;

namespace branef.Application.Members.Notifications;

public class EmpresaNotification(Empresa empresa, ActionType actionType) : INotification
{
    public Empresa Empresa { get; } = empresa;
    public ActionType ActionType { get; } = actionType;
}