using System;
using System.ComponentModel.DataAnnotations;
using AppFidelidade.Core.Dto.Shared;
using AppFidelidade.Core.Entities;

namespace AppFidelidade.Core.Dto.InputModelDto
{
    public class CardInputModelDto: DtoBase<CardInputModelDto, Card>
    {
        public CardInputModelDto() { }

        public CardInputModelDto(Guid clientId)
        {
            ClientId = clientId;
        }

        [Required]
        public Guid ClientId { get; set; }
    }
}