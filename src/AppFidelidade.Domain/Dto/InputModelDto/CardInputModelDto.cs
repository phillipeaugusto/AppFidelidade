using System;
using System.ComponentModel.DataAnnotations;
using AppFidelidade.Domain.Dto.Shared;
using AppFidelidade.Domain.Entities;

namespace AppFidelidade.Domain.Dto.InputModelDto;

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