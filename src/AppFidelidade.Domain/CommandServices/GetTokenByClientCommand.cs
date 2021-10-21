using AppFidelidade.Core.CommandServices.Contracts;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Dto.InputModelDto;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFidelidade.Core.CommandServices
{
    public class GetTokenByClientCommand: Notifiable, IValidator
    {
        public GetTokenByClientCommand() { }

        public GetTokenByClientCommand(LoginInputModelDto loginInputModelDto)
        {
            LoginInputModelDto = loginInputModelDto;
        }

        public LoginInputModelDto LoginInputModelDto { get; set; }
       
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(LoginInputModelDto.Email, "Email", GlobalMessageConstants.FieldInvalidOrNonExistent)
                    .IsNotNull(LoginInputModelDto.PassWord, "PassWord", GlobalMessageConstants.FieldInvalidOrNonExistent)
            );
        }
    }
}