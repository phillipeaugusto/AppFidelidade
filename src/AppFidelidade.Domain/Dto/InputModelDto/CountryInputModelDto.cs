using System.ComponentModel.DataAnnotations;
using AppFidelidade.Domain.Dto.Shared;
using AppFidelidade.Domain.Entities;

namespace AppFidelidade.Domain.Dto.InputModelDto;

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