using System;
using AppFidelidade.Domain.Dto.Shared;
using AppFidelidade.Domain.Entities;

namespace AppFidelidade.Domain.Dto.OutputModelDto;

public class CardOutputModelDto: Dto<CardOutputModelDto, Card> 
{
    public CardOutputModelDto() { }

    public CardOutputModelDto(Guid clientId, string cardNumber, int expirationMonth, int expirationYear, int securityCode)
    {
        ClientId = clientId;
        CardNumber = cardNumber;
        ExpirationMonth = expirationMonth;
        ExpirationYear = expirationYear;
        SecurityCode = securityCode;
    }

    public Guid ClientId { get; set;}
    public string CardNumber { get; set; }
    public int ExpirationMonth { get; set;}
    public int ExpirationYear { get; set; }
    public int SecurityCode { get; set;}

}