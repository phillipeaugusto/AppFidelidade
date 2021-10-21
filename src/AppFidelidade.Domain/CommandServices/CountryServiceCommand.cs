using AppFidelidade.Core.CommandServices.Contracts;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Dto.InputModelDto;
using Flunt.Notifications;
using Flunt.Validations;
using static System.String;

namespace AppFidelidade.Core.CommandServices
{
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
   
}