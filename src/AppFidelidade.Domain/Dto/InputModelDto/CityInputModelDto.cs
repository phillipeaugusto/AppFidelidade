using System.ComponentModel.DataAnnotations;
using AppFidelidade.Core.Dto.OutputModelDto;
using AppFidelidade.Core.Dto.Shared;
using AppFidelidade.Core.Entities;

namespace AppFidelidade.Core.Dto.InputModelDto
{
    public class CityInputModelDto: DtoBase<CityInputModelDto, City>
    {
        public CityInputModelDto() { }

        public CityInputModelDto(string state, string description)
        {
            State = state;
            Description = description;
        }
        [Required]
        public string State { get; set; }
        [Required]
        public string Description { get; set; }
    }
}