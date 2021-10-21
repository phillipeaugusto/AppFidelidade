using System;
using System.Collections.Generic;
using AppFidelidade.Core.Dto.InputModelDto;
using AppFidelidade.Core.Dto.OutputModelDto;

namespace AppFidelidade.Core.Entities
{
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
}