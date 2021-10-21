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
    public class PartnerService:
        Notifiable,
        IService<GetAllService>,
        IService<GetByIdService>,
        IService<CreatePartnerServiceCommand>,
        IService<UpdateParterServiceCommand>,
        IService<RemoveByIdService>,
        IService<GetAllPaginationService>
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly ICityRepository _cityRepository;

        public PartnerService(IPartnerRepository partnerRepository, ICityRepository cityRepository)
        {
            _partnerRepository = partnerRepository;
            _cityRepository = cityRepository;
        }
       
        private async Task<IResult> ValidateDataCreatePartner(CreatePartnerServiceCommand action)
        {
            var cityObj = await _cityRepository.GetById(action.PartnerInputModelDto.CityId);
            var cityValid = cityObj is {};
            
            var partner = await _partnerRepository.GetByCnpjCpf(action.PartnerInputModelDto.CnpjCpf);
            var partnerValid = partner is null;
            
            var result = (cityValid && partnerValid);
            
            return result ? await Result.ResultAsync(true) : await Result.ResultAsync(false, GlobalMessageConstants.EntitieInvalid);
        }
        
        private async Task<IResult> ValidateDataUpdatePartner(UpdateParterServiceCommand action)
        {
            var cityObj = await _cityRepository.GetById(action.PartnerInputModelDto.CityId);
            var cityValid = cityObj is {};
            
            var partner = await _partnerRepository.GetById(action.Id);
            var partnerValid = partner is {};

            var partnerCnpjCpf = await _partnerRepository.GetByCnpjCpf(action.PartnerInputModelDto.CnpjCpf);
            var partnerCnpjCpfValid = partnerCnpjCpf is null || partner.Id == partnerCnpjCpf.Id;
            
            var result = (cityValid && partnerValid && partnerCnpjCpfValid);
            
            return result ? await Result.ResultAsync(true) : await Result.ResultAsync(false, GlobalMessageConstants.EntitieInvalid);
        }

        public async Task<IResult> Service(GetAllService action)
        {
            var obj = await _partnerRepository.GetAll();
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }

        public async Task<IResult> Service(GetByIdService action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var obj = await _partnerRepository.GetById(action.Id);
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }
        
        public async Task<IResult> Service(CreatePartnerServiceCommand action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var objValidation = await ValidateDataCreatePartner(action);

            if (!objValidation.Success)
                return await Result.ResultAsync(false, objValidation.Message);            

            var obj = action.PartnerInputModelDto.ConvertToObject();
            await _partnerRepository.Create(obj);
            
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageSucessRegistred, obj.ConvertToObjectOutPut());
        }

        public async Task<IResult> Service(UpdateParterServiceCommand action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var objValidation = await ValidateDataUpdatePartner(action);

            if (!objValidation.Success)
                return await Result.ResultAsync(false, objValidation.Message);   
 
            var obj = action.PartnerInputModelDto.ConvertToObject();
            obj.SetId(action.Id);

            await _partnerRepository.Update(obj);
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageSucessChange, obj.ConvertToObjectOutPut());
        }

        public async Task<IResult> Service(RemoveByIdService action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var obj = await _partnerRepository.GetById(action.Id);

            if (obj is null)
                return await Result.ResultAsync(false, GlobalMessageConstants.MessageDataNotFound);

            var objConvert = obj.ConvertToObject();
            await _partnerRepository.Delete(objConvert);

            return await Result.ResultAsync(true, GlobalMessageConstants.MessageSucessRemove);
        }

        public async Task<IResult> Service(GetAllPaginationService action)
        {
            action.Validate();
            if (action.Invalid) 
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);
            
            var obj = await _partnerRepository.GetAllPagination(action.PaginationParameters);
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }
    }
}