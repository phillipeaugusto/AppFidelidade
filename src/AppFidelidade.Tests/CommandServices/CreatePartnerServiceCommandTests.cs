using System;
using AppFidelidade.Core.CommandServices;
using AppFidelidade.Core.Dto.InputModelDto;
using Xunit;
using static System.String;

namespace AppFidelidade.Tests.CommandServices
{
    public class CreatePartnerServiceCommandTests
    {
        private readonly CreatePartnerServiceCommand _invalidComand =
            new CreatePartnerServiceCommand(new PartnerInputModelDto(Guid.Empty, Empty, Empty, Empty, Empty));
        private readonly CreatePartnerServiceCommand _validComand = new CreatePartnerServiceCommand(new PartnerInputModelDto(Guid.NewGuid(), "F", "00000000000", "CORPORATENAME", "FANTASYNAME"));

        [Fact]
        public void Given_to_an_invalid_partner()
        {
            _invalidComand.Validate();
            Assert.True(_invalidComand.Invalid);
        }
        
        [Fact]
        public void Given_to_an_valid_partner()
        {
            _validComand.Validate();
            Assert.True(_invalidComand.Valid);
        }
    }
}