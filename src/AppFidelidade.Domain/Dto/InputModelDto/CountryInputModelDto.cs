using System.ComponentModel.DataAnnotations;
using AppFidelidade.Core.Dto.Shared;
using AppFidelidade.Core.Entities;

namespace AppFidelidade.Core.Dto.InputModelDto
{
    public class CountryInputModelDto: DtoBase<CountryInputModelDto, Country>
    {
        public CountryInputModelDto() { }

        public CountryInputModelDto(string description)
        {
            Description = description;
        }
        [Required]
        public string Description { get; set; }
    }
}