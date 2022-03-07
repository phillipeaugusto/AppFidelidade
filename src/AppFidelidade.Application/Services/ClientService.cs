using System.Threading.Tasks;
using AppFidelidade.Application.Services.Contracts;
using AppFidelidade.Core.CommandServices;
using AppFidelidade.Core.CommandServices.Shared;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Repositories;
using AppFidelidade.Core.Shared;
using AppFidelidade.Core.Shared.Contracts;
using Flunt.Notifications;

namespace AppFidelidade.Application.Services
{
    public class ClientService: 
        Notifiable,
        IService<GetAllService>,
        IService<GetByIdService>,
        IService<CreateClientServiceCommand>,
        IService<UpdateClientServiceCommand>,
        IService<RemoveByIdService>,
        IService<GetAllPaginationService>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICityRepository _cityRepository;

        public ClientService(IClientRepository clientRepository, ICityRepository cityRepository)
        {
            _clientRepository = clientRepository;
            _cityRepository = cityRepository;
        }

        private async Task<IResult> ValidateDataCreateClient(CreateClientServiceCommand action)
        {
            var cityObj = await _cityRepository.GetById(action.ClientInputModelDto.CityId);
            var cityValid = cityObj is {};

            var clientObj = await _clientRepository.GetClientValidate(action.ClientInputModelDto.ConvertToObject());
            var clientValid = clientObj is null;
            var result = (cityValid && clientValid);

            if (!result) 
                return await Result.ResultAsync(false, GlobalMessageConstants.EntitieInvalid);
            
            return await Result.ResultAsync(true);
        }
        
        private async Task<IResult> ValidateDataUpdateClient(UpdateClientServiceCommand action)
        {
            var cityObj = await _cityRepository.GetById(action.ClientInputModelDto.CityId);
            var cityValid = cityObj is {};
            
            var client = await _clientRepository.GetById(action.Id);
            var clientValid = client is {};

            var clientByCpf = await _clientRepository.GetByCpf(action.ClientInputModelDto.Cpf);
            var clientCpfValid = clientByCpf is null || client.Id == clientByCpf.Id;

            var clientByEmail = await _clientRepository.GetByEmail(action.ClientInputModelDto.Email);
            var clientByEmailValid = clientByEmail is null || client.Id == clientByEmail.Id;

            var clientByNumber = await _clientRepository.GetByNumber(action.ClientInputModelDto.Number);
            var clientByNumberValid = clientByNumber is null || client.Id == clientByNumber.Id;
            
            var result = (cityValid && clientValid && clientCpfValid && clientByEmailValid && clientByNumberValid);

            if (!result)
                return await Result.ResultAsync(false, GlobalMessageConstants.EntitieInvalid);
            
            return await Result.ResultAsync(true);
        }
        public async Task<IResult> Service(CreateClientServiceCommand action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var objValidation = await ValidateDataCreateClient(action);

            if (!objValidation.Success)
                return await Result.ResultAsync(false, objValidation.Message);            

            var obj = action.ClientInputModelDto.ConvertToObject();
            obj.SetRoleUser();
            obj.SetMd5PassWord();
            
            await _clientRepository.Create(obj);
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageSucessRegistred, obj.ConvertToObjectOutPut());
        }

        public async Task<IResult> Service(RemoveByIdService action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var obj = await _clientRepository.GetById(action.Id);

            if (obj is null)
                return await Result.ResultAsync(false, GlobalMessageConstants.MessageDataNotFound);

            await _clientRepository.Delete(obj.ConvertToObject());
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageSucessRemove, obj);
        }

        public async Task<IResult> Service(UpdateClientServiceCommand action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var objValidation = await ValidateDataUpdateClient(action);

            if (!objValidation.Success)
                return await Result.ResultAsync(false, objValidation.Message);   
 
            var obj = action.ClientInputModelDto.ConvertToObject();
            obj.SetId(action.Id);

            await _clientRepository.Update(obj);
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageSucessChange, obj.ConvertToObjectOutPut());
        }

        public async Task<IResult> Service(GetAllService action)
        {
            var obj = await _clientRepository.GetAll();
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }

        public async Task<IResult> Service(GetByIdService action)
        {
            action.Validate();
            if (action.Invalid) 
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var obj = await _clientRepository.GetById(action.Id);
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }

        public async Task<IResult> Service(GetAllPaginationService action)
        {
            action.Validate();
            if (action.Invalid) 
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);
            
            var obj = await _clientRepository.GetAllPagination(action.PaginationParameters);
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }
    }    
    
}