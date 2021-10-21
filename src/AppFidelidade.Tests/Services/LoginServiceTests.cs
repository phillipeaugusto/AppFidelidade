using System;
using System.Threading.Tasks;
using AppFidelidade.Application.Services;
using AppFidelidade.Core.CommandServices;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Dto.InputModelDto;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Repositories;
using Moq;
using Xunit;
using static System.Threading.Tasks.Task;

namespace AppFidelidade.Tests.Services
{
    public class LoginServiceTests
    {
        private static Mock<IClientRepository> _mockCoutryRepository = new Mock<IClientRepository>();
        private readonly GetTokenByClientCommand _comandGetTokenByClientCommand = new GetTokenByClientCommand(new LoginInputModelDto("user@user.com.br", "123456789"));
        private readonly Client _client = new Client(Guid.NewGuid(), "00000000000", "user01", "00000000000", "user@user.com.br", "123456789", RolesConstant.RoleAdmUser);

        public LoginServiceTests()
        {
            _mockCoutryRepository.Setup(x => x.GetByLogin(It.IsAny<Client>())).Returns(FromResult(_client));
        }
      
        [Fact]
        public async Task Given_to_an_getTokenByClientCommand()
        { 
            var service = new LoginService(_mockCoutryRepository.Object);
            var result = await service.Service(_comandGetTokenByClientCommand);
            Assert.True(result.Success);
        }
    }
}  