using System;
using System.Threading.Tasks;
using AppFidelidade.Domain.Dto.OutputModelDto;
using AppFidelidade.Domain.Entities;
using AppFidelidade.Domain.Repositories.Contracts;

namespace AppFidelidade.Domain.Repositories;

public interface IPartnerRepository: IRepository<Partner, PartnerOutputModelDto>
{
    Task<Partner> GetByCnpjCpf(string cnpjCpf);
    Task<Partner> GetByCnpjCpfById(string cnpjCpf, Guid id);
    Task<Partner> GetByCorporateName(string corporateName);
}