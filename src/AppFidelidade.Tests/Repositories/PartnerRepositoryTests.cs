using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFidelidade.Core.Dto.OutputModelDto;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Pagination;
using AppFidelidade.Core.Repositories;
using Moq;
using Xunit;
using static System.Threading.Tasks.Task;

namespace AppFidelidade.Tests.Repositories
{
    public class PartnerRepositoryTests
    {
        private static Mock<IPartnerRepository> _mockPartnerRepository = new Mock<IPartnerRepository>();
        private static Partner _partner = new Partner(Guid.NewGuid(), "J", "00000000000", "CORPORATENAME", "FANTASYNAME");
        private static PartnerOutputModelDto _partnerOutputModelDto = new PartnerOutputModelDto();

        private List<Partner> _list = new List<Partner>
        {
            new Partner(Guid.NewGuid(), "J", "00000000001", "CORPORATENAME1", "FANTASYNAME1"),
            new Partner(Guid.NewGuid(), "J", "00000000002", "CORPORATENAME1", "FANTASYNAME2")
        };

        private List<PartnerOutputModelDto> _listOutput = new List<PartnerOutputModelDto>
        {
            new PartnerOutputModelDto(Guid.NewGuid(), "J", "00000000001", "CORPORATENAME1", "FANTASYNAME1"),
            new PartnerOutputModelDto(Guid.NewGuid(), "J", "00000000002", "CORPORATENAME2", "FANTASYNAME2")
        };

        public PartnerRepositoryTests()
        {
            _mockPartnerRepository.Setup(x => x.Create(It.IsAny<Partner>()));
            _mockPartnerRepository.Setup(x => x.Delete(It.IsAny<Partner>()));
            _mockPartnerRepository.Setup(x => x.Exists(It.IsAny<Partner>())).Returns(FromResult(_partner));
            _mockPartnerRepository.Setup(x => x.Update(It.IsAny<Partner>()));
            _mockPartnerRepository.Setup(x => x.CreateList(It.IsAny<List<Partner>>()));
            _mockPartnerRepository.Setup(x => x.DeleteList(It.IsAny<List<Partner>>()));
            _mockPartnerRepository.Setup(x => x.UpdateList(It.IsAny<List<Partner>>()));
            _mockPartnerRepository.Setup(x => x.GetAll()).Returns(FromResult(_listOutput));
            _mockPartnerRepository.Setup(x => x.GetAllPagination(new PaginationParameters(1, 10))).Returns(FromResult(new PaginationReturn<PartnerOutputModelDto>(10, 10, 1, _partnerOutputModelDto, 1)));
            _mockPartnerRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_partnerOutputModelDto));
        }

        [Fact]
        public async Task Given_to_an_valid_create()
        {
            await _mockPartnerRepository.Object.Create(_partner);
        }

        [Fact]
        public async Task Given_to_an_valid_delete()
        {
            await _mockPartnerRepository.Object.Delete(_partner);
        }

        [Fact]
        public async Task Given_to_an_valid_exists()
        {
            var obj = await _mockPartnerRepository.Object.Exists(_partner);
            Assert.NotNull(obj);
        }

        [Fact]
        public async Task Given_to_an_valid_update()
        {
            await _mockPartnerRepository.Object.Update(_partner);
        }

        [Fact]
        public async Task Given_to_an_valid_createList()
        {
            await _mockPartnerRepository.Object.CreateList(_list);
        }

        [Fact]
        public async Task Given_to_an_valid_deleteList()
        {
            await _mockPartnerRepository.Object.DeleteList(_list);
        }

        [Fact]
        public async Task Given_to_an_valid_updateList()
        {
            await _mockPartnerRepository.Object.UpdateList(_list);
        }

        [Fact]
        public async Task Given_to_an_valid_getAll()
        {
            var list = await _mockPartnerRepository.Object.GetAll();
            Assert.NotNull(list);
        }

        [Fact]
        public async Task Given_to_an_valid_getById()
        {
            var obj = await _mockPartnerRepository.Object.GetById(new Guid());
            Assert.NotNull(obj);
        }

    }
    
}
