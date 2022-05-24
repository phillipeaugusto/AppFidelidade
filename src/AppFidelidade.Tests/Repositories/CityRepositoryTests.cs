using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFidelidade.Domain.Dto.OutputModelDto;
using AppFidelidade.Domain.Entities;
using AppFidelidade.Domain.Pagination;
using AppFidelidade.Domain.Repositories;
using Moq;
using Xunit;
using static System.Threading.Tasks.Task;

namespace AppFidelidade.Tests.Repositories;

public class CityRepositoryTests
{
    private static Mock<ICityRepository> _mockCityRepository = new Mock<ICityRepository>();
    private static City _city = new City(Guid.NewGuid(), "CITY");
    private static CityOutputModelDto _cityOutputModelDto = new CityOutputModelDto("xxxxxx", Guid.NewGuid());
    private List<City> _list = new List<City>
    {
        new City(Guid.NewGuid(), "xxxxxxx"),
        new City(Guid.NewGuid(), "xxxxxx2")

    };
        
    private List<CityOutputModelDto> _listOutput = new List<CityOutputModelDto>
    {
        new CityOutputModelDto("xxxxxx", Guid.NewGuid()),
        new CityOutputModelDto("xxxxxx", Guid.NewGuid())
    };

    public CityRepositoryTests()
    {
        _mockCityRepository.Setup(x => x.Create(It.IsAny<City>()));
        _mockCityRepository.Setup(x => x.Delete(It.IsAny<City>()));
        _mockCityRepository.Setup(x => x.Exists(It.IsAny<City>())).Returns(FromResult(_city));
        _mockCityRepository.Setup(x => x.Update(It.IsAny<City>()));
        _mockCityRepository.Setup(x => x.CreateList(It.IsAny<List<City>>()));
        _mockCityRepository.Setup(x => x.DeleteList(It.IsAny<List<City>>()));
        _mockCityRepository.Setup(x => x.UpdateList(It.IsAny<List<City>>()));
        _mockCityRepository.Setup(x => x.GetAll()).Returns(FromResult(_listOutput));
        _mockCityRepository.Setup(x => x.GetAllPagination(new PaginationParameters(1,10))).Returns(FromResult(new PaginationReturn<CityOutputModelDto>(10,10,1, _cityOutputModelDto, 1)));
        _mockCityRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_cityOutputModelDto));
    }
        
    [Fact]
    public async Task Given_to_an_valid_create()
    { 
        await _mockCityRepository.Object.Create(_city);
    }
        
    [Fact]
    public async Task Given_to_an_valid_delete()
    {
        await _mockCityRepository.Object.Delete(_city);
    }
        
    [Fact]
    public async Task Given_to_an_valid_exists()
    {
        var obj = await _mockCityRepository.Object.Exists(_city); 
        Assert.NotNull(obj);
    }

    [Fact]
    public async Task Given_to_an_valid_update()
    {
        await _mockCityRepository.Object.Update(_city);
    }
        
    [Fact]
    public async Task Given_to_an_valid_createList()
    {
        await _mockCityRepository.Object.CreateList(_list);
    }
        
    [Fact]
    public async Task Given_to_an_valid_deleteList()
    {
        await _mockCityRepository.Object.DeleteList(_list);
    }
        
    [Fact]
    public async Task Given_to_an_valid_updateList()
    {
        await _mockCityRepository.Object.UpdateList(_list);
    }
        
    [Fact]
    public async Task Given_to_an_valid_getAll()
    { 
        var list = await _mockCityRepository.Object.GetAll();
        Assert.NotNull(list);
    }
        
    [Fact]
    public async Task Given_to_an_valid_getById()
    { 
        var obj = await _mockCityRepository.Object.GetById(new Guid());
        Assert.NotNull(obj);
    }
        
}