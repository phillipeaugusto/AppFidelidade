using System;
using AppFidelidade.Domain.Dto.InputModelDto;
using AppFidelidade.Domain.Dto.OutputModelDto;

namespace AppFidelidade.Domain.Entities;

public class Card: Entity<Card, CardInputModelDto, CardOutputModelDto>
{
    public Card() { }

    public Card(Guid clientId, string cardNumber, int expirationMonth, int expirationYear, int securityCode)
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
    public virtual Client Client { get; set; }
}