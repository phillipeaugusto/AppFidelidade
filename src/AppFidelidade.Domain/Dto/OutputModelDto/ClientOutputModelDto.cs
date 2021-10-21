using System;
using AppFidelidade.Core.Dto.Shared;
using AppFidelidade.Core.Entities;

namespace AppFidelidade.Core.Dto.OutputModelDto
{
    public class ClientOutputModelDto: Dto<ClientOutputModelDto, Client> 
    {
        public ClientOutputModelDto() { }

        public ClientOutputModelDto(Guid cityId, string cpf, string name, string number, string email)
        {
            CityId = cityId;
            Cpf = cpf;
            Name = name;
            Number = number;
            Email = email;
        }

        public Guid CityId { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
}