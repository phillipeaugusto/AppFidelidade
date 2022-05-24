using System.Threading.Tasks;
using AppFidelidade.Application.Services.Contracts;
using AppFidelidade.Domain.CommandServices.Shared;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Repositories;
using AppFidelidade.Domain.Shared;
using AppFidelidade.Domain.Shared.Contracts;
using Flunt.Notifications;

namespace AppFidelidade.Application.Services;

public class CityService:
    Notifiable,
    IService<GetAllService>,
    IService<GetByIdService>,
    IService<GetAllPaginationService>
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<IResult> Service(GetAllService action)
    {
        var obj = await _cityRepository.GetAll();
        return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
    }

    public async Task<IResult> Service(GetByIdService action)
    {
        action.Validate();
        if (action.Invalid)
            return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

        var obj = await _cityRepository.GetById(action.Id);

        if (obj is null) 
            return await Result.ResultAsync(false, GlobalMessageConstants.MessageDataNotFound, action.Id);
            
        return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
    }

    public async Task<IResult> Service(GetAllPaginationService action)
    {
        action.Validate();
        if (action.Invalid) 
            return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);
            
        var obj = await _cityRepository.GetAllPagination(action.PaginationParameters);
        return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
    }
}