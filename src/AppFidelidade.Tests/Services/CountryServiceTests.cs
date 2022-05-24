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

public class CountryServiceTests
{
    private static Mock<ICountryRepository> _mockCoutryRepository = new Mock<ICountryRepository>();
    private readonly GetAllService _comandGetAllService = new GetAllService();
    private readonly GetByIdService _comandGetByIdService = new GetByIdService(Guid.NewGuid());
    private readonly CountryOutputModelDto _countryOutputModelDto = new CountryOutputModelDto("COUNTRYXXX");
    private readonly GetAllPaginationService _comandGetAllPaginationService = new GetAllPaginationService(new PaginationParameters(1, 10));
    private readonly List<CountryOutputModelDto> _list = new List<CountryOutputModelDto>{
        new CountryOutputModelDto("COUNTRY01"),
        new CountryOutputModelDto("COUNTRY02")
    };
        

    public CountryServiceTests()
    {
        _mockCoutryRepository.Setup(x => x.GetAll()).Returns(FromResult(_list));
        _mockCoutryRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_countryOutputModelDto));
    }
      
    [Fact]
    public async Task Given_to_an_getAllCard()
    {
        var service = new CountryService(_mockCoutryRepository.Object);
        var result = await service.Service(_comandGetAllService);
        Assert.True(result.Success);
    }
        
    [Fact]
    public async Task Given_to_an_getByIdService()
    {
        var service = new CountryService(_mockCoutryRepository.Object);
        var result = await service.Service(_comandGetByIdService);
        Assert.True(result.Success);
    }
        
    [Fact]
    public async Task Given_to_an_getAllPaginationService()
    {
        var service = new CountryService(_mockCoutryRepository.Object);
        var result = await service.Service(_comandGetAllPaginationService);
        Assert.True(result.Success);
    }
}