using System;
using AppFidelidade.Core.CommandServices;
using Xunit;

namespace AppFidelidade.Tests.CommandServices
{
    public class GetCardByClientIdCommandTests
    {
        private readonly GetCardByClientIdCommand _invalidComand = new GetCardByClientIdCommand(Guid.Empty);
        private readonly GetCardByClientIdCommand _validComand = new GetCardByClientIdCommand(Guid.NewGuid());

        [Fact]
        public void Given_to_an_invalid_getcardbyclientid()
        {
            _invalidComand.Validate();
            Assert.False(_invalidComand.Invalid);
        }
        
        [Fact]
        public void Given_to_an_valid_getcardbyclientid()
        {
            _validComand.Validate();
            Assert.True(_invalidComand.Valid);
        }
    }
}