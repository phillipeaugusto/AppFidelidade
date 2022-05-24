using AppFidelidade.Domain.Dto.OutputModelDto;
using AppFidelidade.Domain.Entities;
using AppFidelidade.Domain.Repositories.Contracts;

namespace AppFidelidade.Domain.Repositories;

public interface ICountryRepository: IRepository<Country, CountryOutputModelDto>
{
        
}