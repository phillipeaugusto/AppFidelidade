using System;
using AppFidelidade.Core.CommandServices.Contracts;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Dto.InputModelDto;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFidelidade.Core.CommandServices
{
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
}