using System;
using AppFidelidade.Domain.Dto.InputModelDto;
using AppFidelidade.Domain.Dto.OutputModelDto;

namespace AppFidelidade.Domain.Entities;

public class Partner: Entity<Partner, PartnerInputModelDto, PartnerOutputModelDto>
{
    public Partner() { }

    public Partner(Guid cityId, string personType, string cnpjCpf, string corporateName, string fantasyName)
    {
        CityId = cityId;
        PersonType = personType;
        CnpjCpf = cnpjCpf;
        CorporateName = corporateName;
        FantasyName = fantasyName;
    }

    public Guid CityId { get; set; }
    public string PersonType { get; set; }
    public string CnpjCpf { get; set; }
    public string CorporateName { get; set; }
    public string FantasyName { get; set;}
    public City City { get; set; }
        
}