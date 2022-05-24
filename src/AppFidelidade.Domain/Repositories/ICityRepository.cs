using AppFidelidade.Domain.Dto.OutputModelDto;
using AppFidelidade.Domain.Entities;
using AppFidelidade.Domain.Repositories.Contracts;

namespace AppFidelidade.Domain.Repositories;

public interface ICityRepository: IRepository<City, CityOutputModelDto>
{
}