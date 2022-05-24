using AppFidelidade.Domain.CommandServices;
using AppFidelidade.Domain.Dto.InputModelDto;
using Xunit;
using static System.String;

namespace AppFidelidade.Tests.CommandServices;

public class GetTokenByClientCommandTests
{
    private readonly GetTokenByClientCommand _invalidComand = new GetTokenByClientCommand(new LoginInputModelDto(Empty, Empty));
    private readonly GetTokenByClientCommand _validComand = new GetTokenByClientCommand(new LoginInputModelDto("user@user.com.br", "123456789"));

    [Fact]
    public void Given_to_an_invalid_gettokenbyclient()
    {
        _invalidComand.Validate();
        Assert.False(_invalidComand.Invalid);
    }
        
    [Fact]
    public void Given_to_an_valid_gettokenbyclient()
    {
        _validComand.Validate();
        Assert.True(_invalidComand.Valid);
    }
}