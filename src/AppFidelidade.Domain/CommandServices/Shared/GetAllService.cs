using AppFidelidade.Domain.CommandServices.Contracts;
using Flunt.Notifications;

namespace AppFidelidade.Domain.CommandServices.Shared;

public class GetAllService: Notifiable, IValidator
{
    public void Validate() { }
}