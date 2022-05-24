using System;
using AppFidelidade.Domain.Dto.Shared;
using AppFidelidade.Domain.Entities;

namespace AppFidelidade.Domain.Dto.OutputModelDto;

public class CityOutputModelDto: Dto<CityOutputModelDto, City> 
{
    public CityOutputModelDto() { }

    public CityOutputModelDto(string description, Guid countryId)
    {
        Description = description;
        CountryId = countryId;
    }

    public string Description { get; set; }
    public Guid CountryId { get; set; }
}