using System;
using AppFidelidade.Domain.Dto.Shared;
using AppFidelidade.Domain.Entities;

namespace AppFidelidade.Domain.Dto.OutputModelDto;

public class PartnerOutputModelDto: Dto<PartnerOutputModelDto, Partner> 
{
    public PartnerOutputModelDto() { }

    public PartnerOutputModelDto(Guid cityId, string personType, string cnpjCpf, string corporateName, string fantasyName)
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
}