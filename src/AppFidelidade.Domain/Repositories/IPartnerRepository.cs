using System;
using System.Threading.Tasks;
using AppFidelidade.Core.Dto.OutputModelDto;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Repositories.Contracts;

namespace AppFidelidade.Core.Repositories
{
    public interface IPartnerRepository: IRepository<Partner, PartnerOutputModelDto>
    {
        Task<Partner> GetByCnpjCpf(string cnpjCpf);
        Task<Partner> GetByCnpjCpfById(string cnpjCpf, Guid id);
        Task<Partner> GetByCorporateName(string corporateName);
    }
}