using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFidelidade.Application.Services;
using AppFidelidade.Domain.CommandServices;
using AppFidelidade.Domain.CommandServices.Shared;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Dto.InputModelDto;
using AppFidelidade.Domain.Dto.OutputModelDto;
using AppFidelidade.Domain.Entities;
using AppFidelidade.Domain.Pagination;
using AppFidelidade.Domain.Repositories;
using Moq;
using Xunit;
using static System.String;
using static System.Threading.Tasks.Task;

namespace AppFidelidade.Tests.Services;

public class ClientServiceTests
{
    private static Mock<IClientRepository> _mockClientRepository = new Mock<IClientRepository>();
    private static Mock<ICityRepository> _mockCityRepository = new Mock<ICityRepository>();
    private readonly City _city = new City(Guid.NewGuid(), "CITY");
    private readonly CityOutputModelDto _cityOutputModelDto = new CityOutputModelDto("CITY", Guid.NewGuid());
    private static Client _client = new Client(Guid.NewGuid(), "00000000000", "NAME123", "0000000", "USER@USER.COM.BR", "123456789", RolesConstant.RoleAdmUser);
    private static ClientInputModelDto _cardClientInputModelDtoValid = new ClientInputModelDto("00000000000", "NAME123", "0000000000000", "USER@USER.COM.BR", "123456789", Guid.NewGuid());
    private static ClientInputModelDto _cardClientInputModelDtoInValid = new ClientInputModelDto(Empty, Empty, Empty, Empty, Empty, Guid.Empty);
    private static ClientOutputModelDto _clientOutputDto = new ClientOutputModelDto(Guid.NewGuid(), "00000000001", "NAME", "0000000", "USER@USER.COM.BR");
    private readonly GetAllPaginationService _comandGetAllPaginationService = new GetAllPaginationService(new PaginationParameters(1, 10));
    private readonly GetAllService _comandGetAllService = new GetAllService();
    private readonly GetByIdService _comandGetByIdService = new GetByIdService(Guid.NewGuid());
    private readonly RemoveByIdService _comandRemoveByIdService = new RemoveByIdService(Guid.NewGuid());
    private readonly CreateClientServiceCommand _comandCreateClientServiceCommandValid = new CreateClientServiceCommand(_cardClientInputModelDtoValid);
    private readonly CreateClientServiceCommand _comandCreateClientServiceCommandInvalid = new CreateClientServiceCommand(_cardClientInputModelDtoInValid);
    private readonly UpdateClientServiceCommand _comandUpdateClientServiceCommandValid = new UpdateClientServiceCommand(_cardClientInputModelDtoValid, Guid.NewGuid());
    private readonly UpdateClientServiceCommand _comandUpdateClientServiceCommandInvalid = new UpdateClientServiceCommand(_cardClientInputModelDtoInValid, Guid.Empty);
    private readonly List<ClientOutputModelDto> _list = new List<ClientOutputModelDto>{
        new ClientOutputModelDto(Guid.NewGuid(), "00000000001", "NAME1", "0000000000000", "USER@USER.COM.BR"),
        new ClientOutputModelDto(Guid.NewGuid(), "00000000002", "NAME2", "0000000000002", "USER2@USER.COM.BR")
    };

    public ClientServiceTests()
    {

        _mockClientRepository.Setup(x => x.Create(It.IsAny<Client>()));
        _mockClientRepository.Setup(x => x.Delete(It.IsAny<Client>()));
        _mockClientRepository.Setup(x => x.Exists(It.IsAny<Client>())).Returns(FromResult(_client));
        _mockClientRepository.Setup(x => x.Update(It.IsAny<Client>()));
            
        _mockCityRepository.Setup(x => x.Create(It.IsAny<City>()));
        _mockCityRepository.Setup(x => x.Delete(It.IsAny<City>()));
        _mockCityRepository.Setup(x => x.Exists(It.IsAny<City>())).Returns(FromResult(_city));
        _mockCityRepository.Setup(x => x.Update(It.IsAny<City>()));
    }
        
    [Fact]
    public async Task Given_to_an_invalid_createClient()
    {
        var service = new ClientService(_mockClientRepository.Object, _mockCityRepository.Object);
        var result = await service.Service(_comandCreateClientServiceCommandInvalid);
        Assert.False(result.Success);
    }
        
    [Fact]
    public async Task Given_to_an_valid_createClient()
    {
        _mockCityRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_cityOutputModelDto));

        var service = new ClientService(_mockClientRepository.Object, _mockCityRepository.Object);
        var result = await service.Service(_comandCreateClientServiceCommandValid);
        Assert.True(result.Success);
    }
        
    [Fact]
    public async Task Given_to_an_GetAllService()
    {
        _mockClientRepository.Setup(x => x.GetAll()).Returns(FromResult(_list));
        var service = new ClientService(_mockClientRepository.Object, _mockCityRepository.Object);
        var result = await service.Service(_comandGetAllService);
        Assert.True(result.Success);
    }
        
    [Fact]
    public async Task Given_to_an_GetByIdService()
    {
        _mockClientRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_clientOutputDto));
        var service = new ClientService(_mockClientRepository.Object, _mockCityRepository.Object);
        var result = await service.Service(_comandGetByIdService);
        Assert.True(result.Success);
    }
        
    [Fact]
    public async Task Given_to_an_RemoveByIdService()
    {
        _mockClientRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_clientOutputDto));
        var service = new ClientService(_mockClientRepository.Object, _mockCityRepository.Object);
        var result = await service.Service(_comandRemoveByIdService);
        Assert.True(result.Success);
    }
        
    [Fact]
    public async Task Given_to_an_invalid_updateClient()
    {
        _mockClientRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_clientOutputDto));
        var service = new ClientService(_mockClientRepository.Object, _mockCityRepository.Object);
        var result = await service.Service(_comandUpdateClientServiceCommandInvalid);
        Assert.False(result.Success);
    }
        
    [Fact]
    public async Task Given_to_an_valid_updateClient()
    {
        _mockCityRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_cityOutputModelDto));
        _mockClientRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_clientOutputDto));
        var service = new ClientService(_mockClientRepository.Object, _mockCityRepository.Object);
        var result = await service.Service(_comandUpdateClientServiceCommandValid);
        Assert.True(result.Success);
    }
    [Fact]
    public async Task Given_to_an_getAllPaginationService()
    {
        var service = new ClientService(_mockClientRepository.Object,  _mockCityRepository.Object);
        var result = await service.Service(_comandGetAllPaginationService);
        Assert.True(result.Success);
    }
}