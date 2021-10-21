using System.Threading.Tasks;
using AppFidelidade.Core.Dto.OutputModelDto;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Repositories.Contracts;

namespace AppFidelidade.Core.Repositories
{
    public interface IClientRepository: IRepository<Client, ClientOutputModelDto>
    {
        public Task<Client> GetByCpf(string cnpjCpf);
        public Task<Client> GetByEmail(string email);
        public Task<Client> GetByNumber(string number);
        public Task<Client> GetByLogin(Client client);
    }
}