using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFidelidade.Core.Dto.OutputModelDto;
using AppFidelidade.Core.Entities;
using AppFidelidade.Core.Pagination;
using AppFidelidade.Core.Repositories;
using AppFidelidade.Infrastructure.Contexts;
using AppFidelidade.Infrastructure.Repositories.Pagination;
using Microsoft.EntityFrameworkCore;

namespace AppFidelidade.Infrastructure.Repositories
{
    public class ClientRepository: IClientRepository
    {
        private readonly DataContext _context;
        
        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Client entity)
        {
            _context.Client.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Client entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Client entity)
        {
            _context.Client.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientOutputModelDto> GetById(Guid id)
        {
            var obj = await _context.Client
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return obj?.ConvertToObjectOutPut();
        }

        public async Task<List<ClientOutputModelDto>> GetAll()
        {
            return await _context.Client
                .AsNoTracking()
                .Select(x => x.ConvertToObjectOutPut())
                .ToListAsync();
        }

        public async Task<PaginationReturn<ClientOutputModelDto>> GetAllPagination(PaginationParameters paginationParameters)
        {
            return await new PaginationReturnRepository<Client, ClientOutputModelDto>(paginationParameters, _context.Client)
                .ReturnDataPagination();
        }

        public async Task<List<ClientOutputModelDto>> GetAll(char status)
        {
            return await _context.Client
                .AsNoTracking()
                .Where(x => x.Status == status)
                .Select(x => x.ConvertToObjectOutPut())
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Client> Exists(Client entity)
        {
            return await _context.Client
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Cpf == entity.Cpf && x.Email.ToUpper() == entity.Email.ToUpper());
        }

        public async Task CreateList(IEnumerable<Client> list)
        {
            foreach (var obj in list)
            { 
                _context.Client.Add(obj);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateList(IEnumerable<Client> list)
        {
            foreach (var dados in list)
            { 
                _context.Entry(dados).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteList(IEnumerable<Client> list)
        {
            foreach (var obj in list)
            { 
                _context.Client.Remove(obj);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetByCpf(string cpf)
        {
            return await _context.Client
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public async Task<Client> GetByEmail(string email)
        {
            return await _context.Client
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Client> GetByNumber(string number)
        {
            return await _context.Client
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Number == number);
        }

        public async Task<Client> GetByLogin(Client client)
        {
            return await _context.Client
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == client.Email && x.PassWord == client.PassWord);
        }
    }
}