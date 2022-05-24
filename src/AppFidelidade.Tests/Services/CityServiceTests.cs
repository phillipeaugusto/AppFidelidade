using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFidelidade.Application.Services;
using AppFidelidade.Domain.CommandServices.Shared;
using AppFidelidade.Domain.Dto.OutputModelDto;
using AppFidelidade.Domain.Pagination;
using AppFidelidade.Domain.Repositories;
using Moq;
using Xunit;
using static System.Threading.Tasks.Task;

namespace AppFidelidade.Tests.Services;

public class CityServiceTests
{
    private static Mock<ICityRepository> _mockCityRepository = new Mock<ICityRepository>();
    private readonly GetAllService _comandGetAllService = new GetAllService();
    private readonly GetByIdService _comandGetByIdService = new GetByIdService(Guid.NewGuid());
    private readonly GetAllPaginationService _comandGetAllPaginationService = new GetAllPaginationService(new PaginationParameters(1,10));
    private readonly CityOutputModelDto _cityOutputModelDto = new CityOutputModelDto("CITYXXX", Guid.NewGuid());
    private readonly List<CityOutputModelDto> _list = new List<CityOutputModelDto>{
        new CityOutputModelDto("CITY01", Guid.NewGuid()),
        new CityOutputModelDto("CITY02", Guid.NewGuid())
    };
        

    public CityServiceTests()
    {
        _mockCityRepository.Setup(x => x.GetAll()).Returns(FromResult(_list));
        _mockCityRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_cityOutputModelDto));
    }
        
      
    [Fact]
    public async Task Given_to_an_getAllCard()
    {
        var service = new CityService(_mockCityRepository.Object);
        var result = await service.Service(_comandGetAllService);
        Assert.True(result.Success);
    }
        
    [Fact]
    public async Task Given_to_an_getByIdService()
    {
        var service = new CityService(_mockCityRepository.Object);
        var result = await service.Service(_comandGetByIdService);
        Assert.True(result.Success);
    }
        
    [Fact]
    public async Task Given_to_an_getAllPaginationService()
    {
        var service = new CityService(_mockCityRepository.Object);
        var result = await service.Service(_comandGetAllPaginationService);
        Assert.True(result.Success);
    }
}