using AppFidelidade.Domain.Dto.Shared;
using AppFidelidade.Domain.Entities;

namespace AppFidelidade.Domain.Dto.OutputModelDto;

public class CountryOutputModelDto: Dto<CountryOutputModelDto, Country> 
{
    public CountryOutputModelDto() { }

    public CountryOutputModelDto(string description)
    {
        Description = description;
    }

    public string Description { get; set; }
        
}