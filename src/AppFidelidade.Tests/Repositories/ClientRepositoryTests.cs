using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Dto.OutputModelDto;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Pagination;
using AppFidelidade.Core.Repositories;
using Moq;
using Xunit;
using static System.Threading.Tasks.Task;

namespace AppFidelidade.Tests.Repositories
{
    public class ClientRepositoryTests
    {
        private static Mock<IClientRepository> _mockClientRepository = new Mock<IClientRepository>();
        private static Client _client = new Client(Guid.NewGuid(), "00000000000", "NAME123", "0000000", "USER@USER.COM.BR", "123456789", RolesConstant.RoleAdmUser);
        private static ClientOutputModelDto _clientOutputModelDto = new ClientOutputModelDto(Guid.NewGuid(), "00000000001", "NAME", "0000000000000", "USER@USER.COM.BR");

        private List<Client> _list = new List<Client>
        {
            new Client(Guid.NewGuid(), "00000000001", "NAME1231", "0000000", "USER1@USER.COM.BR", "123456788", RolesConstant.RoleAdmUser),
            new Client(Guid.NewGuid(), "00000000002", "NAME1232", "0000000", "USER2@USER.COM.BR", "123456789", RolesConstant.RoleAdmUser)

        };

        private List<ClientOutputModelDto> _listOutput = new List<ClientOutputModelDto>
        {
            new ClientOutputModelDto(Guid.NewGuid(), "00000000001", "NAME", "0000000000001", "USER1@USER.COM.BR"),
            new ClientOutputModelDto(Guid.NewGuid(), "00000000002", "NAME", "0000000000002", "USER2@USER.COM.BR")
        };

        public ClientRepositoryTests()
        {
            _mockClientRepository.Setup(x => x.Create(It.IsAny<Client>()));
            _mockClientRepository.Setup(x => x.Delete(It.IsAny<Client>()));
            _mockClientRepository.Setup(x => x.Exists(It.IsAny<Client>())).Returns(FromResult(_client));
            _mockClientRepository.Setup(x => x.Update(It.IsAny<Client>()));
            _mockClientRepository.Setup(x => x.CreateList(It.IsAny<List<Client>>()));
            _mockClientRepository.Setup(x => x.DeleteList(It.IsAny<List<Client>>()));
            _mockClientRepository.Setup(x => x.UpdateList(It.IsAny<List<Client>>()));
            _mockClientRepository.Setup(x => x.GetAll()).Returns(FromResult(_listOutput));
            _mockClientRepository.Setup(x => x.GetAllPagination(new PaginationParameters(1, 10)))
                .Returns(FromResult(new PaginationReturn<ClientOutputModelDto>(10, 10, 1, _clientOutputModelDto, 1)));
            _mockClientRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_clientOutputModelDto));
        }

        [Fact]
        public async Task Given_to_an_valid_create()
        {
            await _mockClientRepository.Object.Create(_client);
        }

        [Fact]
        public async Task Given_to_an_valid_delete()
        {
            await _mockClientRepository.Object.Delete(_client);
        }

        [Fact]
        public async Task Given_to_an_valid_exists()
        {
            var obj = await _mockClientRepository.Object.Exists(_client);
            Assert.NotNull(obj);
        }

        [Fact]
        public async Task Given_to_an_valid_update()
        {
            await _mockClientRepository.Object.Update(_client);
        }

        [Fact]
        public async Task Given_to_an_valid_createList()
        {
            await _mockClientRepository.Object.CreateList(_list);
        }

        [Fact]
        public async Task Given_to_an_valid_deleteList()
        {
            await _mockClientRepository.Object.DeleteList(_list);
        }

        [Fact]
        public async Task Given_to_an_valid_updateList()
        {
            await _mockClientRepository.Object.UpdateList(_list);
        }

        [Fact]
        public async Task Given_to_an_valid_getAll()
        {
            var list = await _mockClientRepository.Object.GetAll();
            Assert.NotNull(list);
        }

        [Fact]
        public async Task Given_to_an_valid_getById()
        {
            var obj = await _mockClientRepository.Object.GetById(new Guid());
            Assert.NotNull(obj);
        }

    }
}
