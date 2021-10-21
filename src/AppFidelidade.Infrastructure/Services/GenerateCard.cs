using System;
using AppFidelidade.Core.Entities;

namespace AppFidelidade.Infrastructure.Services
{
    public static class GenerateCard
    {
        private static string CardNumber()
        {
            var rnd = new Random();
            var cardNumber = "";
            for (uint ctr = 1; ctr <= 16; ctr++)
                cardNumber += rnd.Next(9);

            return cardNumber;
        }
        
        private static int CardSecurityCodeNumber()
        {
            var rnd = new Random();
            var cardSecurity = "";
            for (uint ctr = 1; ctr <= 3; ctr++)
                cardSecurity += rnd.Next(9);

            return int.Parse(cardSecurity);
        }
        public static Card Generate(Guid clientId)
        {
            var cardNumber = CardNumber();
            var cardSecurityCodeNumber = CardSecurityCodeNumber();
            var expirationMonth = DateTime.Now.Month;
            var expirationYear = DateTime.Now.Year + 2;

            return new Card(clientId, cardNumber, expirationMonth, expirationYear, cardSecurityCodeNumber);
        }
    }
}