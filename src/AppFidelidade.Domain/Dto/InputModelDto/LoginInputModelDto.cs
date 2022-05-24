using System.ComponentModel.DataAnnotations;
using AppFidelidade.Domain.Dto.Shared;
using AppFidelidade.Domain.Entities;

namespace AppFidelidade.Domain.Dto.InputModelDto;

public class LoginInputModelDto: DtoBase<LoginInputModelDto, Client>
{
    public LoginInputModelDto() { }

    public LoginInputModelDto(string email, string passWord)
    {
        Email = email;
        PassWord = passWord;
    }

    [Required]
    public string Email { get; set; }
    [Required]
    public string PassWord { get; set; }
}