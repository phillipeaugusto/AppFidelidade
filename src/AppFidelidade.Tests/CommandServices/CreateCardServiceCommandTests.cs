using System;
using AppFidelidade.Core.CommandServices;
using AppFidelidade.Core.Dto.InputModelDto;
using Xunit;

namespace AppFidelidade.Tests.CommandServices
{
    public class CreateCardServiceCommandTests
    {
        private readonly CreateCardServiceCommand _invalidComand = new CreateCardServiceCommand(new CardInputModelDto(Guid.Empty));
        private readonly CreateCardServiceCommand _validComand = new CreateCardServiceCommand(new CardInputModelDto(Guid.NewGuid()));

        [Fact]
        public void Given_to_an_invalid_card()
        {
            _invalidComand.Validate();
            Assert.False(_invalidComand.Invalid);
        }
        
        [Fact]
        public void Given_to_an_valid_card()
        {
            _validComand.Validate();
            Assert.True(_invalidComand.Valid);
        }

    }
}