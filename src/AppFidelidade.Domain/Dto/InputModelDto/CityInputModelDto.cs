using System.ComponentModel.DataAnnotations;
using AppFidelidade.Domain.Dto.Shared;
using AppFidelidade.Domain.Entities;

namespace AppFidelidade.Domain.Dto.InputModelDto;

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