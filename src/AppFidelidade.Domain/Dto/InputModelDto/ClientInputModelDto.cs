using System;
using System.ComponentModel.DataAnnotations;
using AppFidelidade.Domain.Dto.Shared;
using AppFidelidade.Domain.Entities;

namespace AppFidelidade.Domain.Dto.InputModelDto;

public class ClientInputModelDto: DtoBase<ClientInputModelDto, Client>
{
    public ClientInputModelDto() { }

    public ClientInputModelDto(string cpf, string name, string number, string email, string passWord, Guid cityId)
    {
        Cpf = cpf;
        Name = name;
        Number = number;
        Email = email;
        PassWord = passWord;
        CityId = cityId;
    }
    [Required]
    public string Cpf { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Number { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string PassWord { get; set; }
    [Required]
    public Guid CityId { get; set; }
}