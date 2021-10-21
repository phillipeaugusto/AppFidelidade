using AppFidelidade.Core.CommandServices.Contracts;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Dto.InputModelDto;
using Flunt.Notifications;
using Flunt.Validations;
using static System.String;

namespace AppFidelidade.Core.CommandServices.Card
{
    
    public class CardServiceBase: Notifiable, IValidator
    {
        public CardServiceBase(CardInputModelDto cardInputModelDto)
        {
            CardInputModelDto = cardInputModelDto;
        }
        public CardInputModelDto CardInputModelDto { get; set;}
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsTrue(CardInputModelDto.CardNumber == Empty, "CardNumber", GlobalConstants.FieldInvalidOrInvalidOrNonExistent)
                    .IsNotNull(CardInputModelDto.ClientId, "ClientId", GlobalConstants.FieldInvalidOrInvalidOrNonExistent)
                    .IsTrue(CardInputModelDto.ExpirationMonth <= 0, "ExpirationMonth", GlobalConstants.FieldInvalidOrInvalidOrNonExistent)
                    .IsTrue(CardInputModelDto.ExpirationYear <= 0, "ExpirationYear", GlobalConstants.FieldInvalidOrInvalidOrNonExistent)
                    .IsTrue(CardInputModelDto.SecurityCode <= 0, "SecurityCode", GlobalConstants.FieldInvalidOrInvalidOrNonExistent)
            );
        }
    }
}