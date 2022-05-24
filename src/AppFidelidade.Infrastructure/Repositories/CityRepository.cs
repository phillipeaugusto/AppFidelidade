using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFidelidade.Domain.Dto.OutputModelDto;
using AppFidelidade.Domain.Entities;
using AppFidelidade.Domain.Pagination;
using AppFidelidade.Domain.Repositories;
using AppFidelidade.Infrastructure.Contexts;
using AppFidelidade.Infrastructure.Repositories.Pagination;
using Microsoft.EntityFrameworkCore;

namespace AppFidelidade.Infrastructure.Repositories;

public class CityRepository: ICityRepository
{
    private readonly DataContext _context;
        
    public CityRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(City entity)
    {
        _context.City.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(City entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(City entity)
    {
        _context.City.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<CityOutputModelDto> GetById(Guid id)
    {
        var obj = await _context.City
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.Id == id);

        return obj?.ConvertToObjectOutPut();
    }

    public async Task<List<CityOutputModelDto>> GetAll()
    {
        return await _context.City
            .AsNoTrackingWithIdentityResolution()
            .Select(x => x.ConvertToObjectOutPut())
            .ToListAsync();
    }

    public async Task<PaginationReturn<CityOutputModelDto>> GetAllPagination(PaginationParameters paginationParameters)
    {
        return await new PaginationReturnRepository<City, CityOutputModelDto>(paginationParameters, _context.City)
            .ReturnDataPagination();
    }

    public async Task<List<CityOutputModelDto>> GetAll(char status)
    {
        return await _context.City
            .AsNoTrackingWithIdentityResolution()
            .Where(x => x.Status == status)
            .Select(x => x.ConvertToObjectOutPut())
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<City> Exists(City entity)
    {
        return await _context.City.AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.Description == entity.Description && x.CountryId == entity.CountryId);
    }

    public async Task CreateList(IEnumerable<City> list)
    {
        foreach (var obj in list)
        { 
            _context.City.Add(obj);
        }
        await _context.SaveChangesAsync();
    }

    public async Task UpdateList(IEnumerable<City> list)
    {
        foreach (var dados in list)
        { 
            _context.Entry(dados).State = EntityState.Modified;
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteList(IEnumerable<City> list)
    {
        foreach (var obj in list)
        { 
            _context.City.Remove(obj);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<City> GetByDescription(string description)
    {
        return await _context.City.AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.Description.ToUpper() == description.ToUpper());
    }
}