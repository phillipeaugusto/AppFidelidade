using System;
using System.Threading.Tasks;
using AppFidelidade.Core.Dto.OutputModelDto;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Repositories.Contracts;

namespace AppFidelidade.Core.Repositories
{
    public interface ICardRepository: IRepository<Card, CardOutputModelDto>
    {
        Task<CardOutputModelDto> GetCardByClientId(Guid clientId);
    }
}