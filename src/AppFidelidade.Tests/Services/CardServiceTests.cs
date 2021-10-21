using System;
using System.Threading.Tasks;
using AppFidelidade.Application.Services;
using AppFidelidade.Core.CommandServices;
using AppFidelidade.Core.CommandServices.Shared;
using AppFidelidade.Core.Dto.InputModelDto;
using AppFidelidade.Core.Dto.OutputModelDto;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Pagination;
using AppFidelidade.Core.Repositories;
using Moq;
using Xunit;
using static System.Threading.Tasks.Task;

namespace AppFidelidade.Tests.Services
{
    public class CardServiceTests
    {
        private static Mock<ICardRepository>  _mockCardRepository = new Mock<ICardRepository>();
        private static CardOutputModelDto _cardOutputModelDto = new CardOutputModelDto(Guid.NewGuid(), "999999999999", 1, 2022, 213);
        private static CardInputModelDto _cardInputModelDtoValid = new CardInputModelDto(Guid.NewGuid());
        private static CardInputModelDto _cardInputModelDtoInValid = new CardInputModelDto(Guid.Empty);
        private static Card _card = new Card(Guid.NewGuid(), "999999999999", 1, 2022, 213);
        private readonly GetAllPaginationService _comandPaginationServiceValid = new GetAllPaginationService(new PaginationParameters(1, 10));
        private readonly CreateCardServiceCommand _comandCreateCardServiceCommandValid = new CreateCardServiceCommand(_cardInputModelDtoValid);
        private readonly CreateCardServiceCommand _comandCreateCardServiceCommandInvalid = new CreateCardServiceCommand(_cardInputModelDtoInValid);
        private readonly GetByIdService _comandGetByIdServiceValid = new GetByIdService(Guid.NewGuid());
        private readonly GetByIdService _comandGetByIdServiceInvalid = new GetByIdService(Guid.Empty);
        private readonly GetCardByClientIdCommand _comandGetCardByClientIdCommand = new GetCardByClientIdCommand(Guid.NewGuid());

        public CardServiceTests()
        {
            _mockCardRepository.Setup(x => x.Create(It.IsAny<Card>()));
            _mockCardRepository.Setup(x => x.Delete(It.IsAny<Card>()));
            _mockCardRepository.Setup(x => x.Exists(It.IsAny<Card>())).Returns(FromResult(_card));
            _mockCardRepository.Setup(x => x.Update(It.IsAny<Card>()));
        }

        [Fact]
        public async Task Given_to_an_invalid_createCard()
        {
            _mockCardRepository.Setup(x => x.GetCardByClientId(It.IsAny<Guid>())).Returns(FromResult(_cardOutputModelDto));
            var service = new CardService(_mockCardRepository.Object);
            var result = await service.Service(_comandCreateCardServiceCommandInvalid);
            Assert.False(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_valid_createCard()
        {
            var service = new CardService(_mockCardRepository.Object);
            var result = await service.Service(_comandCreateCardServiceCommandValid);
            Assert.True(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_invalid_getByIdService()
        {
            var service = new CardService(_mockCardRepository.Object);
            var result = await service.Service(_comandGetByIdServiceInvalid);
            Assert.False(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_valid_getByIdService()
        {
            _mockCardRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_cardOutputModelDto));
            var service = new CardService(_mockCardRepository.Object);
            var result = await service.Service(_comandGetByIdServiceValid);
            Assert.True(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_valid_getAllPaginationService()
        {
            _mockCardRepository.Setup(x => x.GetAllPagination(It.IsAny<PaginationParameters>())).Returns(FromResult(new PaginationReturn<CardOutputModelDto>(10,10,1, _cardOutputModelDto, 1)));
            var service = new CardService(_mockCardRepository.Object);
            var result = await service.Service(_comandPaginationServiceValid);
            Assert.True(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_valid_getCardByClientIdCommand()
        {
            _mockCardRepository.Setup(x => x.GetCardByClientId(It.IsAny<Guid>())).Returns(FromResult(_cardOutputModelDto));
            var service = new CardService(_mockCardRepository.Object);
            var result = await service.Service(_comandGetCardByClientIdCommand);
            Assert.True(result.Success);
        }
    }
}