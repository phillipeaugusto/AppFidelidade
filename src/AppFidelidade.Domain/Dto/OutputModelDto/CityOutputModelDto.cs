using System;
using AppFidelidade.Core.Dto.Shared;
using AppFidelidade.Core.Entities;

namespace AppFidelidade.Core.Dto.OutputModelDto
{
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
}