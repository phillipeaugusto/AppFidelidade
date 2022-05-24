using AppFidelidade.Domain.CommandServices;
using AppFidelidade.Domain.Dto.InputModelDto;
using Xunit;
using static System.String;

namespace AppFidelidade.Tests.CommandServices;

public class CountryServiceCommandTests
{
    private readonly CountryServiceCommand _invalidComand = new CountryServiceCommand(new CountryInputModelDto(Empty));
    private readonly CountryServiceCommand _validComand = new CountryServiceCommand(new CountryInputModelDto("Brasil"));

    [Fact]
    public void Given_to_an_invalid_country()
    {
        _invalidComand.Validate();
        Assert.False(_invalidComand.Invalid);
    }
        
    [Fact]
    public void Given_to_an_valid_country()
    {
        _validComand.Validate();
        Assert.True(_invalidComand.Valid);
    }
}