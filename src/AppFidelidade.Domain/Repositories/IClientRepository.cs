using System.Threading.Tasks;
using AppFidelidade.Domain.Dto.OutputModelDto;
using AppFidelidade.Domain.Entities;
using AppFidelidade.Domain.Repositories.Contracts;

namespace AppFidelidade.Domain.Repositories;

public interface IClientRepository: IRepository<Client, ClientOutputModelDto>
{
    public Task<Client> GetByCpf(string cnpjCpf);
    public Task<Client> GetByEmail(string email);
    public Task<Client> GetByNumber(string number);
    public Task<Client> GetByLogin(Client client);
    public Task<Client> GetClientValidate(Client client);
}