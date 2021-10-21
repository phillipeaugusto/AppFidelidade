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
    public class CountryRepository: ICountryRepository
    {
        private readonly DataContext _context;
        
        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Country entity)
        {
            _context.Country.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Country entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Country entity)
        {
            _context.Country.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<CountryOutputModelDto> GetById(Guid id)
        {
            var obj = await _context.Country
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return obj?.ConvertToObjectOutPut();
        }

        public async Task<List<CountryOutputModelDto>> GetAll()
        {
            return await _context.Country
                .AsNoTracking()
                .Select(x => x.ConvertToObjectOutPut())
                .ToListAsync();
        }

        public async Task<PaginationReturn<CountryOutputModelDto>> GetAllPagination(PaginationParameters paginationParameters)
        { 
            return await new PaginationReturnRepository<Country, CountryOutputModelDto>(paginationParameters, _context.Country)
                .ReturnDataPagination();
        }

        public async Task<List<CountryOutputModelDto>> GetAll(char status)
        {
            return await _context.Country
                .AsNoTracking()
                .Where(x => x.Status == status)
                .Select(x => x.ConvertToObjectOutPut())
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Country> Exists(Country entity)
        {
            return await _context.Country
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Description == entity.Description);
        }

        public async Task CreateList(IEnumerable<Country> list)
        {
            foreach (var obj in list)
            { 
                _context.Country.Add(obj);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateList(IEnumerable<Country> list)
        {
            foreach (var dados in list)
            { 
                _context.Entry(dados).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteList(IEnumerable<Country> list)
        {
            foreach (var obj in list)
            { 
                _context.Country.Remove(obj);
            }
            await _context.SaveChangesAsync();
        }
    }
}