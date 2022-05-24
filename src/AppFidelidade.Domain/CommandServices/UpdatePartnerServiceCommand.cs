using System;
using AppFidelidade.Domain.CommandServices.Contracts;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Dto.InputModelDto;
using Flunt.Notifications;
using Flunt.Validations;
using static System.String;

namespace AppFidelidade.Domain.CommandServices;

public class UpdateParterServiceCommand: Notifiable, IValidator
{
    public UpdateParterServiceCommand(PartnerInputModelDto partnerInputModelDto, Guid id)
    {
        PartnerInputModelDto = partnerInputModelDto;
        Id = id;
    }
    public PartnerInputModelDto PartnerInputModelDto { get; set;}
    public Guid Id { get; set;}
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsFalse(PartnerInputModelDto.CnpjCpf == Empty, "CnpjCpf",GlobalMessageConstants.FieldInvalidOrNonExistent)
                .IsFalse(PartnerInputModelDto.CnpjCpf.Length < 11, "CnpjCpf",GlobalMessageConstants.NumberOfInvalidCharacters)
                .IsFalse(PartnerInputModelDto.CorporateName == Empty, "CorporateName",GlobalMessageConstants.FieldInvalidOrNonExistent)
                .IsFalse(PartnerInputModelDto.CorporateName.Length < 5, "CorporateName",GlobalMessageConstants.NumberOfInvalidCharacters)
                .IsFalse(PartnerInputModelDto.FantasyName == Empty, "FantasyName",GlobalMessageConstants.FieldInvalidOrNonExistent)
                .IsFalse(PartnerInputModelDto.FantasyName.Length < 5, "FantasyName",GlobalMessageConstants.NumberOfInvalidCharacters)
                .IsFalse(PartnerInputModelDto.PersonType == Empty, "PersonType",GlobalMessageConstants.FieldInvalidOrNonExistent)
                .IsNotEmpty(PartnerInputModelDto.CityId, "CityId",GlobalMessageConstants.FieldInvalidOrNonExistent)
                .IsNotEmpty(Id, "Id",GlobalMessageConstants.FieldInvalidOrNonExistent)
        );
    }
}