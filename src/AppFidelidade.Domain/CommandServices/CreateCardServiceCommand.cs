using System;
using AppFidelidade.Domain.CommandServices.Contracts;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Dto.InputModelDto;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFidelidade.Domain.CommandServices;

public class CreateCardServiceCommand: Notifiable, IValidator
{
    public CreateCardServiceCommand() { }

    public CreateCardServiceCommand(CardInputModelDto cardInputModelDto)
    {
        CardInputModelDto = cardInputModelDto;
    }

    public CardInputModelDto CardInputModelDto { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsFalse(CardInputModelDto.ClientId == Guid.Empty, "ClientId", GlobalMessageConstants.FieldInvalidOrNonExistent)
        );
    }
}