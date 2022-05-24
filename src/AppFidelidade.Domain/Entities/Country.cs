using System;
using System.Collections.Generic;
using AppFidelidade.Domain.Dto.InputModelDto;
using AppFidelidade.Domain.Dto.OutputModelDto;

namespace AppFidelidade.Domain.Entities;

public class Country: Entity<Country, CountryInputModelDto, CountryOutputModelDto>
{
    public Country() { }

    public Country(Guid id, string description)
    {
        Id = id;
        Description = description;
    }
        

    public string Description { get; set; }
    public virtual ICollection<City> City { get; set; }
}