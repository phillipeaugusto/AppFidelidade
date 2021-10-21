﻿using System.Threading.Tasks;
using AppFidelidade.Core.Dto.OutputModelDto;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Repositories.Contracts;

namespace AppFidelidade.Core.Repositories
{
    public interface ICityRepository: IRepository<City, CityOutputModelDto>
    {
    }
}