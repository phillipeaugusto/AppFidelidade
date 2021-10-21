using System.ComponentModel.DataAnnotations;
using AppFidelidade.Core.Dto.Shared;
using AppFidelidade.Core.Entities;

namespace AppFidelidade.Core.Dto.InputModelDto
{
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
}