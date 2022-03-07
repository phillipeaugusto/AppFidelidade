using System;
using AppFidelidade.Core.CommandServices;
using AppFidelidade.Core.Dto.InputModelDto;
using Xunit;
using static System.String;

namespace AppFidelidade.Tests.CommandServices
{
    public class CreateClientServiceCommandTests
    {
        private readonly CreateClientServiceCommand _invalidComand = new CreateClientServiceCommand(new ClientInputModelDto(Empty, Empty, Empty, Empty, Empty, Guid.Empty));
        private readonly CreateClientServiceCommand _validComand = new CreateClientServiceCommand(new ClientInputModelDto("00000000000","NAME123","0000000", "USER@USER.COM.BR", "123456789", Guid.NewGuid()));

        [Fact]
        public void Given_to_an_invalid_client()
        {
            _invalidComand.Validate();
            Assert.True(_invalidComand.Invalid);
        }
        
        [Fact]
        public void Given_to_an_valid_client()
        {
            _validComand.Validate();
            Assert.True(_invalidComand.Valid);
        }
    }
}