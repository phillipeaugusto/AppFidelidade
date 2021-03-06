using System;
using System.Collections.Generic;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Dto.InputModelDto;
using AppFidelidade.Domain.Dto.OutputModelDto;
using AppFidelidade.Domain.Functions;

namespace AppFidelidade.Domain.Entities;

public class Client: Entity<Client, ClientInputModelDto, ClientOutputModelDto>
{
    public Client() { }

    public Client(Guid cityId, string cpf, string name, string number, string email, string passWord, string role)
    {
        CityId = cityId;
        Cpf = cpf;
        Name = name;
        Number = number;
        Email = email;
        PassWord = passWord;
        Role = role;
    }

        
    public Guid CityId { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public string Email { get; set; }
    public string PassWord { get; set; }
    public string Role { get; set; }
    public City City { get; set; }
    public virtual ICollection<Card> Card { get; set; }
        
    public void SetRoleUser()
    {
        Role = RolesConstant.RoleUser;
    }
        
    public void SetMd5PassWord()
    {
        PassWord = Function.GenerateMd5(PassWord);
    }
}