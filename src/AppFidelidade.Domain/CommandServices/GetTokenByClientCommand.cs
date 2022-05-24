using AppFidelidade.Domain.CommandServices.Contracts;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Dto.InputModelDto;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFidelidade.Domain.CommandServices;

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