using System.Threading.Tasks;
using AppFidelidade.Application.Services.Contracts;
using AppFidelidade.Core.CommandServices.Shared;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Repositories;
using AppFidelidade.Core.Shared;
using AppFidelidade.Core.Shared.Contracts;
using Flunt.Notifications;

namespace AppFidelidade.Application.Services
{
    public class CountryService:
        Notifiable,
        IService<GetAllService>,
        IService<GetByIdService>,
        IService<GetAllPaginationService>
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IResult> Service(GetAllService action)
        {
            var obj = await _countryRepository.GetAll();
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }

        public async Task<IResult> Service(GetByIdService action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var obj = await _countryRepository.GetById(action.Id);
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }

        public async Task<IResult> Service(GetAllPaginationService action)
        {
            action.Validate();
            if (action.Invalid) 
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);
            
            var obj = await _countryRepository.GetAllPagination(action.PaginationParameters);
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }
    }
}