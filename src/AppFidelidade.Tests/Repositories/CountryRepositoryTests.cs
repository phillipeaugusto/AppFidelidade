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

public class CountryRepositoryTests
{
    private static Mock<ICountryRepository> _mockCountryRepository = new Mock<ICountryRepository>();
    private static Country _client = new Country(Guid.Parse("f97def59-a619-4a97-adb3-f38852a6ad45"), "xxxxxxxx");
    private static CountryOutputModelDto _countryOutputModelDto = new CountryOutputModelDto();

    private List<Country> _list = new List<Country>
    {
        new Country(Guid.Parse("f97def59-a619-4a97-adb3-f38852a6ad45"), "xxxxxx1"),
        new Country(Guid.Parse("f97def59-a619-4a97-adb3-f38852a6ad45"), "xxxxxx2")
    };

    private List<CountryOutputModelDto> _listOutput = new List<CountryOutputModelDto>
    {
        new CountryOutputModelDto("Xxxxxxx1"),
        new CountryOutputModelDto("Xxxxxxx2")
    };

    public CountryRepositoryTests()
    {
        _mockCountryRepository.Setup(x => x.Create(It.IsAny<Country>()));
        _mockCountryRepository.Setup(x => x.Delete(It.IsAny<Country>()));
        _mockCountryRepository.Setup(x => x.Exists(It.IsAny<Country>())).Returns(FromResult(_client));
        _mockCountryRepository.Setup(x => x.Update(It.IsAny<Country>()));
        _mockCountryRepository.Setup(x => x.CreateList(It.IsAny<List<Country>>()));
        _mockCountryRepository.Setup(x => x.DeleteList(It.IsAny<List<Country>>()));
        _mockCountryRepository.Setup(x => x.UpdateList(It.IsAny<List<Country>>()));
        _mockCountryRepository.Setup(x => x.GetAll()).Returns(FromResult(_listOutput));
        _mockCountryRepository.Setup(x => x.GetAllPagination(new PaginationParameters(1, 10))).Returns(FromResult(new PaginationReturn<CountryOutputModelDto>(10, 10, 1, _countryOutputModelDto, 1)));
        _mockCountryRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_countryOutputModelDto));
    }

    [Fact]
    public async Task Given_to_an_valid_create()
    {
        await _mockCountryRepository.Object.Create(_client);
    }

    [Fact]
    public async Task Given_to_an_valid_delete()
    {
        await _mockCountryRepository.Object.Delete(_client);
    }

    [Fact]
    public async Task Given_to_an_valid_exists()
    {
        var obj = await _mockCountryRepository.Object.Exists(_client);
        Assert.NotNull(obj);
    }

    [Fact]
    public async Task Given_to_an_valid_update()
    {
        await _mockCountryRepository.Object.Update(_client);
    }

    [Fact]
    public async Task Given_to_an_valid_createList()
    {
        await _mockCountryRepository.Object.CreateList(_list);
    }

    [Fact]
    public async Task Given_to_an_valid_deleteList()
    {
        await _mockCountryRepository.Object.DeleteList(_list);
    }

    [Fact]
    public async Task Given_to_an_valid_updateList()
    {
        await _mockCountryRepository.Object.UpdateList(_list);
    }

    [Fact]
    public async Task Given_to_an_valid_getAll()
    {
        var list = await _mockCountryRepository.Object.GetAll();
        Assert.NotNull(list);
    }

    [Fact]
    public async Task Given_to_an_valid_getById()
    {
        var obj = await _mockCountryRepository.Object.GetById(new Guid());
        Assert.NotNull(obj);
    }

}