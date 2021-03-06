using System;
using AppFidelidade.Domain.CommandServices.Contracts;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Dto.InputModelDto;
using Flunt.Notifications;
using Flunt.Validations;
using static System.String;

namespace AppFidelidade.Domain.CommandServices;

public class UpdateClientServiceCommand: Notifiable, IValidator
{
    public UpdateClientServiceCommand(ClientInputModelDto clientInputModelDto, Guid id)
    {
        ClientInputModelDto = clientInputModelDto;
        Id = id;
    }
    public ClientInputModelDto ClientInputModelDto { get; set;}
    public Guid Id;
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsFalse(ClientInputModelDto.Cpf == Empty, "Cpf",GlobalMessageConstants.FieldInvalidOrNonExistent)
                .HasMinLen(ClientInputModelDto.Cpf, 11,"Cpf",GlobalMessageConstants.NumberOfInvalidCharacters)
                .IsFalse(ClientInputModelDto.Name == Empty, "Name",GlobalMessageConstants.FieldInvalidOrNonExistent)
                .HasMinLen(ClientInputModelDto.Name, 5,"Name",GlobalMessageConstants.NumberOfInvalidCharacters)
                .IsFalse(ClientInputModelDto.Number == Empty, "Number",GlobalMessageConstants.FieldInvalidOrNonExistent)
                .HasMinLen(ClientInputModelDto.Number, 10,"Number",GlobalMessageConstants.NumberOfInvalidCharacters)
                .IsFalse(ClientInputModelDto.PassWord == Empty, "PassWord",GlobalMessageConstants.FieldInvalidOrNonExistent)
                .HasMinLen(ClientInputModelDto.PassWord, 4,"PassWord",GlobalMessageConstants.NumberOfInvalidCharacters)
                .IsEmail(ClientInputModelDto.Email, "Email", GlobalMessageConstants.FieldInvalidOrNonExistent)
        );
    }
}