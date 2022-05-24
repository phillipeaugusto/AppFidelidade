using System;
using AppFidelidade.Domain.CommandServices.Contracts;
using AppFidelidade.Domain.Constants;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFidelidade.Domain.CommandServices.Shared;

public class GetByIdService: Notifiable, IValidator
{
    public GetByIdService(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsNotNull(Id, "Id", GlobalMessageConstants.FieldInvalidOrNonExistent)
        );
    }
}