using System;
using System.Collections.Generic;
using AppFidelidade.Core.Dto.InputModelDto;
using AppFidelidade.Core.Dto.OutputModelDto;

namespace AppFidelidade.Core.Entities
{
    public class City: Entity<City, CityInputModelDto, CityOutputModelDto>
    {
        public City() { }

        public City(Guid countryId, string description)
        {
            CountryId = countryId;
            Description = description;
        }

        public Guid CountryId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Partner> Partner { get; set; }
        public virtual Country Country { get; set; }
    }
}