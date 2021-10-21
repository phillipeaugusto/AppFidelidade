using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Dto.Shared;

namespace AppFidelidade.Core.Dto.OutputModelDto
{
    public class CountryOutputModelDto: Dto<CountryOutputModelDto, Country> 
    {
        public CountryOutputModelDto() { }

        public CountryOutputModelDto(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
        
    }
}