using System.Dynamic;
using System.Threading.Tasks;
using AppFidelidade.Application.Services.Contracts;
using AppFidelidade.Core.CommandServices;
using AppFidelidade.Core.CommandServices.Contracts;
using AppFidelidade.Core.CommandServices.Shared;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Repositories;
using AppFidelidade.Core.Shared;
using AppFidelidade.Core.Shared.Contracts;
using AppFidelidade.Infrastructure.Services;
using Flunt.Notifications;

namespace AppFidelidade.Application.Services
{
    public class LoginService:
        Notifiable,
        IService<GetTokenByClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public LoginService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        private ExpandoObject GenerateToken(Client client)
        {
            dynamic obj = new ExpandoObject();
            obj.Token = TokenService.GenerateToken(client);
            obj.ClientId = client.Id;
            return obj;
        }
        
        public async Task<IResult> Service(GetTokenByClientCommand action)
        {
            action.Validate();
            if (action.Invalid)
                return await Result.ResultAsync(false, GlobalMessageConstants.ReturnInconsistenciesMessage, action.Notifications);

            var objTemp = action.LoginInputModelDto.ConvertToObject();
            objTemp.SetMd5PassWord();
            var obj = await _clientRepository.GetByLogin(objTemp);

            if (obj is null)
                return await Result.ResultAsync(false, GlobalMessageConstants.InvalidAccessData);
            
            return await Result.ResultAsync(true, GlobalMessageConstants.MessageEmpty, GenerateToken(obj));
        }
    }
}     