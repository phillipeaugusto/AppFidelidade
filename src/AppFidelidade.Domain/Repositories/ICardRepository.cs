using System;
using System.Threading.Tasks;
using AppFidelidade.Domain.Dto.OutputModelDto;
using AppFidelidade.Domain.Entities;
using AppFidelidade.Domain.Repositories.Contracts;

namespace AppFidelidade.Domain.Repositories;

public interface ICardRepository: IRepository<Card, CardOutputModelDto>
{
    Task<CardOutputModelDto> GetCardByClientId(Guid clientId);
}