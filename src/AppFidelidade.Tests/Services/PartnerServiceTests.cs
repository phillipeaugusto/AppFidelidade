using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFidelidade.Application.Services;
using AppFidelidade.Core.CommandServices;
using AppFidelidade.Core.CommandServices.Shared;
using AppFidelidade.Core.Dto.InputModelDto;
using AppFidelidade.Core.Dto.OutputModelDto;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Repositories;
using Moq;
using Xunit;
using static System.String;
using static System.Threading.Tasks.Task;

namespace AppFidelidade.Tests.Services
{
    public class PartnerServiceTests
    {
        private static Mock<IPartnerRepository> _mockPartnerRepository = new Mock<IPartnerRepository>();
        private static Mock<ICityRepository> _mockCityRepository = new Mock<ICityRepository>();
        private static PartnerInputModelDto _cardPartnerInputModelDtoValid = new PartnerInputModelDto(Guid.NewGuid(), "F", "00000000000", "CORPORATENAME", "FANTASYNAME");
        private static PartnerInputModelDto _cardPartnerInputModelDtoInValid = new PartnerInputModelDto(Guid.Empty, Empty, Empty, Empty, Empty);
        private static PartnerOutputModelDto _partnerOutputDto = new PartnerOutputModelDto(Guid.NewGuid(), "J", "00000000001", "CORPORATENAME1", "FANTASYNAME1");
        private readonly Partner _partner = new Partner(Guid.NewGuid(), "J", "00000000000", "CORPORATENAME", "FANTASYNAME");
        private readonly City _city = new City(Guid.NewGuid(), "CITY");
        private readonly CityOutputModelDto _cityOutputModelDto = new CityOutputModelDto("CITY", Guid.NewGuid());
        private readonly GetAllService _comandGetAllService = new GetAllService();
        private readonly GetByIdService _comandGetByIdService = new GetByIdService(Guid.NewGuid());
        private readonly RemoveByIdService _comandRemoveByIdService = new RemoveByIdService(Guid.NewGuid());
        private readonly CreatePartnerServiceCommand _comandCreatePartnerServiceCommandValid = new CreatePartnerServiceCommand(_cardPartnerInputModelDtoValid);
        private readonly CreatePartnerServiceCommand _comandCreatePartnerServiceCommandInvalid = new CreatePartnerServiceCommand(_cardPartnerInputModelDtoInValid);
        private readonly UpdateParterServiceCommand _comandUpdateParterServiceCommandValid = new UpdateParterServiceCommand(_cardPartnerInputModelDtoValid, Guid.NewGuid());
        private readonly UpdateParterServiceCommand _comandUpdateParterServiceCommandInvalid = new UpdateParterServiceCommand(_cardPartnerInputModelDtoInValid, Guid.Empty);

        private readonly List<PartnerOutputModelDto> _list = new List<PartnerOutputModelDto>{
            new PartnerOutputModelDto(Guid.NewGuid(), "J", "00000000001", "CORPORATENAME1", "FANTASYNAME1"),
            new PartnerOutputModelDto(Guid.NewGuid(), "J", "00000000002", "CORPORATENAME2", "FANTASYNAME2")
        };

        public PartnerServiceTests()
        {
            _mockPartnerRepository.Setup(x => x.Create(It.IsAny<Partner>()));
            _mockPartnerRepository.Setup(x => x.Delete(It.IsAny<Partner>()));
            _mockPartnerRepository.Setup(x => x.Exists(It.IsAny<Partner>())).Returns(FromResult(_partner));
            _mockPartnerRepository.Setup(x => x.Update(It.IsAny<Partner>()));
            
            _mockCityRepository.Setup(x => x.Create(It.IsAny<City>()));
            _mockCityRepository.Setup(x => x.Delete(It.IsAny<City>()));
            _mockCityRepository.Setup(x => x.Exists(It.IsAny<City>())).Returns(FromResult(_city));
            _mockCityRepository.Setup(x => x.Update(It.IsAny<City>()));
        }
        
        [Fact]
        public async Task Given_to_an_invalid_createPartner()
        {
            var service = new PartnerService(_mockPartnerRepository.Object, _mockCityRepository.Object);
            var result = await service.Service(_comandCreatePartnerServiceCommandInvalid);
            Assert.False(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_valid_createPartner()
        {
            _mockPartnerRepository.Setup(x => x.GetByCorporateName(It.IsAny<string>())).Returns(FromResult(_partner));
            _mockPartnerRepository.Setup(x => x.GetByCnpjCpfById(It.IsAny<string>(), It.IsAny<Guid>())).Returns(FromResult(_partner));
            _mockCityRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_cityOutputModelDto));

            var service = new PartnerService(_mockPartnerRepository.Object, _mockCityRepository.Object);
            var result = await service.Service(_comandCreatePartnerServiceCommandValid);
            Assert.True(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_GetAllService()
        {
            _mockPartnerRepository.Setup(x => x.GetAll()).Returns(FromResult(_list));
            var service = new PartnerService(_mockPartnerRepository.Object, _mockCityRepository.Object);
            var result = await service.Service(_comandGetAllService);
            Assert.True(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_GetByIdService()
        {
            _mockPartnerRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_partnerOutputDto));
            var service = new PartnerService(_mockPartnerRepository.Object, _mockCityRepository.Object);
            var result = await service.Service(_comandGetByIdService);
            Assert.True(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_RemoveByIdService()
        {
            _mockPartnerRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_partnerOutputDto));
            var service = new PartnerService(_mockPartnerRepository.Object, _mockCityRepository.Object);
            var result = await service.Service(_comandRemoveByIdService);
            Assert.True(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_invalid_updatePartner()
        {
            _mockPartnerRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_partnerOutputDto));
            var service = new PartnerService(_mockPartnerRepository.Object, _mockCityRepository.Object);
            var result = await service.Service(_comandUpdateParterServiceCommandInvalid);
            Assert.False(result.Success);
        }
        
        [Fact]
        public async Task Given_to_an_valid_updatePartner()
        {
            _mockCityRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_cityOutputModelDto));
            _mockPartnerRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_partnerOutputDto));
            var service = new PartnerService(_mockPartnerRepository.Object, _mockCityRepository.Object);
            var result = await service.Service(_comandUpdateParterServiceCommandValid);
            Assert.True(result.Success);
        }
    }
}