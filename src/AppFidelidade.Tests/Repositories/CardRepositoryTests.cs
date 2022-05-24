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

public class CardRepositoryTests
{
    private static Mock<ICardRepository> _mockCardRepository = new Mock<ICardRepository>();
    private static Card _card = new Card(Guid.NewGuid(), "999999999999", 1, 2022, 213);
    private static CardOutputModelDto _cardOutputModelDto = new CardOutputModelDto(Guid.NewGuid(), "999999999999", 1, 2022, 213);
    private List<Card> _list = new List<Card>
    {
        new Card(Guid.NewGuid(), "999999999999", 1, 2022, 213),
        new Card(Guid.NewGuid(), "999999999998", 2, 2023, 214)
    };
        
    private List<CardOutputModelDto> _listOutput = new List<CardOutputModelDto>
    {
        new CardOutputModelDto(Guid.NewGuid(), "999999999999", 1, 2022, 213),
        new CardOutputModelDto(Guid.NewGuid(), "999999999998", 2, 2023, 214)
    };

    public CardRepositoryTests()
    {
        _mockCardRepository.Setup(x => x.Create(It.IsAny<Card>()));
        _mockCardRepository.Setup(x => x.Delete(It.IsAny<Card>()));
        _mockCardRepository.Setup(x => x.Exists(It.IsAny<Card>())).Returns(FromResult(_card));
        _mockCardRepository.Setup(x => x.Update(It.IsAny<Card>()));
        _mockCardRepository.Setup(x => x.CreateList(It.IsAny<List<Card>>()));
        _mockCardRepository.Setup(x => x.DeleteList(It.IsAny<List<Card>>()));
        _mockCardRepository.Setup(x => x.UpdateList(It.IsAny<List<Card>>()));
        _mockCardRepository.Setup(x => x.GetAll()).Returns(FromResult(_listOutput));
        _mockCardRepository.Setup(x => x.GetAllPagination(new PaginationParameters(1,10))).Returns(FromResult(new PaginationReturn<CardOutputModelDto>(1,1,1, _cardOutputModelDto, 1)));
        _mockCardRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_cardOutputModelDto));
    }
        
    [Fact]
    public async Task Given_to_an_valid_create()
    { 
        await _mockCardRepository.Object.Create(_card);
    }
        
    [Fact]
    public async Task Given_to_an_valid_delete()
    {
        await _mockCardRepository.Object.Delete(_card);
    }
        
    [Fact]
    public async Task Given_to_an_valid_exists()
    {
        var obj = await _mockCardRepository.Object.Exists(_card); 
        Assert.NotNull(obj);
    }

    [Fact]
    public async Task Given_to_an_valid_update()
    {
        await _mockCardRepository.Object.Update(_card);
    }
        
    [Fact]
    public async Task Given_to_an_valid_createList()
    {
        await _mockCardRepository.Object.CreateList(_list);
    }
        
    [Fact]
    public async Task Given_to_an_valid_deleteList()
    {
        await _mockCardRepository.Object.DeleteList(_list);
    }
         
    [Fact]
    public async Task Given_to_an_valid_updateList()
    {
        await _mockCardRepository.Object.UpdateList(_list);
    }
        
    [Fact]
    public async Task Given_to_an_valid_getAll()
    { 
        var list = await _mockCardRepository.Object.GetAll();
        Assert.NotNull(list);
    }
        
    [Fact]
    public async Task Given_to_an_valid_getById()
    { 
        var obj = await _mockCardRepository.Object.GetById(new Guid());
        Assert.NotNull(obj);
    }
        
}