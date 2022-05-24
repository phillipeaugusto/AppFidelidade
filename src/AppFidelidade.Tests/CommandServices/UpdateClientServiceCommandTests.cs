using System;
using AppFidelidade.Domain.CommandServices;
using AppFidelidade.Domain.Dto.InputModelDto;
using Xunit;
using static System.String;

namespace AppFidelidade.Tests.CommandServices;

public class UpdateClientServiceCommandTests
{
    private readonly UpdateClientServiceCommand _invalidComand = new UpdateClientServiceCommand(new ClientInputModelDto(Empty,Empty,Empty,Empty,Empty, Guid.Empty), Guid.Empty);
    private readonly UpdateClientServiceCommand _validComand = new UpdateClientServiceCommand(new ClientInputModelDto("00000000000","NAME123","0000000", "USER@USER.COM.BR", "123456789", Guid.NewGuid()), Guid.NewGuid());

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