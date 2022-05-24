using System;
using System.ComponentModel.DataAnnotations;
using AppFidelidade.Domain.Dto.Shared;
using AppFidelidade.Domain.Entities;

namespace AppFidelidade.Domain.Dto.InputModelDto;

public class PartnerInputModelDto: DtoBase<PartnerInputModelDto, Partner>
{
    public PartnerInputModelDto() { }

    public PartnerInputModelDto(Guid cityId, string personType, string cnpjCpf, string corporateName, string fantasyName)
    {
        CityId = cityId;
        PersonType = personType;
        CnpjCpf = cnpjCpf;
        CorporateName = corporateName;
        FantasyName = fantasyName;
    }
    [Required]
    public Guid CityId { get; set; }
    [Required]
    public string PersonType { get; set; }
    [Required]
    public string CnpjCpf { get; set; }
    [Required]
    public string CorporateName { get; set; }
    [Required]
    public string FantasyName { get; set;}
}