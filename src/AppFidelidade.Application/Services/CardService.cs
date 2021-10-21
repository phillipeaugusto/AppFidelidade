using System.Threading.Tasks;
using AppFidelidade.Application.Services.Contracts;
using AppFidelidade.Core.CommandServices;
using AppFidelidade.Core.CommandServices.Shared;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Repositories;
using AppFidelidade.Core.Shared;
using AppFidelidade.Core.Shared.Contracts;
using AppFidelidade.Infrastructure.Services;
using Flunt.Notifications;

namespace AppFidelidade.Application.Services
{
    public class CardService:
        Notifiable,
        IService<GetAllPaginationService>,
        IService<GetByIdService>,
        IService<CreateCardServiceCommand>,
        IService<GetCardByClientIdCommand>
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        
        private async Task<IResult> ValidateDataCreateCard(CreateCardServiceCommand action)
        {
            
            var cardByClientId = await _cardRepository.GetCardByClientId(action.CardInputModelDto.ClientId);
            var cardByClientIdValid = cardByClientId is null;

            var result = cardByClientIdValid;

            return result ? await Result.ResultAsync(true) : await Result.ResultAsync(false, GlobalMessageConstants.EntitieInvalid);
        }

        public async Task<IResult> Service(GetAllPaginationService action)
        {
            action.Validate();
            if (action.Invalid) 
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);
            
            var obj = await _cardRepository.GetAllPagination(action.PaginationParameters);
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }

        public async Task<IResult> Service(GetByIdService action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var obj = await _cardRepository.GetById(action.Id);

            if (obj is null) 
                return await Result.ResultAsync(false, GlobalMessageConstants.MessageDataNotFound);
            
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }

        public async Task<IResult> Service(CreateCardServiceCommand action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var objValidation = await ValidateDataCreateCard(action);

            if (!objValidation.Success)
                return await Result.ResultAsync(false, objValidation.Message);

            var obj = GenerateCard.Generate(action.CardInputModelDto.ClientId);
            await _cardRepository.Create(obj);

            return await Result.ResultAsync(true, GlobalMessageConstants.MessageSucessRegistred, obj.ConvertToObjectOutPut());
        }

        public async Task<IResult> Service(GetCardByClientIdCommand action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);
            
            var obj = await _cardRepository.GetCardByClientId(action.Id);
            
            if (obj is null) 
                return await Result.ResultAsync(false, GlobalMessageConstants.MessageDataNotFound);
            
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, obj);
        }
    }
}