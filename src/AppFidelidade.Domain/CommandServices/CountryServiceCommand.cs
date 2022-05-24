using AppFidelidade.Domain.CommandServices.Contracts;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Dto.InputModelDto;
using Flunt.Notifications;
using Flunt.Validations;
using static System.String;

namespace AppFidelidade.Domain.CommandServices;

public class CountryServiceCommand: Notifiable, IValidator
{
    public CountryServiceCommand(CountryInputModelDto countryInputModelDto)
    {

        CountryInputModelDto = countryInputModelDto;
    }
    public CountryInputModelDto CountryInputModelDto { get; set;}
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsTrue(CountryInputModelDto.Description == Empty, "Description", GlobalMessageConstants.FieldInvalidOrNonExistent)
        );
    }
}