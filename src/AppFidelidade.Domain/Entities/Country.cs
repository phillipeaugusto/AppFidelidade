using System.Collections.Generic;
using AppFidelidade.Core.Dto.InputModelDto;
using AppFidelidade.Core.Dto.OutputModelDto;

namespace AppFidelidade.Core.Entities
{
    public class Country: Entity<Country, CountryInputModelDto, CountryOutputModelDto>
    {
        public Country() { }

        public Country(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}