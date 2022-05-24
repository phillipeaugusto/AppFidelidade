using System;
using AppFidelidade.Domain.CommandServices;
using AppFidelidade.Domain.Dto.InputModelDto;
using Xunit;
using static System.String;

namespace AppFidelidade.Tests.CommandServices;

public class UpdatePartnerServiceCommandTests
{
    private readonly UpdateParterServiceCommand _invalidComand = new UpdateParterServiceCommand(new PartnerInputModelDto(Guid.Empty, Empty, Empty, Empty, Empty), Guid.Empty);
    private readonly UpdateParterServiceCommand _validComand = new UpdateParterServiceCommand(new PartnerInputModelDto(new Guid(), "F", "00000000000", "CORPORATENAME", "FANTASYNAME"), new Guid());

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