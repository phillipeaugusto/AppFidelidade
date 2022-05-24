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

public class PartnerRepository: IPartnerRepository
{
    private readonly DataContext _context;
        
    public PartnerRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(Partner entity)
    {
        _context.Partner.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Partner entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Partner entity)
    {
        _context.Partner.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<PartnerOutputModelDto> GetById(Guid id)
    {
        var obj = await _context.Partner
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.Id == id);
            
        return obj?.ConvertToObjectOutPut();
    }

    public async Task<List<PartnerOutputModelDto>> GetAll()
    {
        return await _context.Partner
            .AsNoTrackingWithIdentityResolution()
            .Select(x => x.ConvertToObjectOutPut())
            .ToListAsync();
    }

    public async Task<PaginationReturn<PartnerOutputModelDto>> GetAllPagination(PaginationParameters paginationParameters)
    {
        return await new PaginationReturnRepository<Partner, PartnerOutputModelDto>(paginationParameters, _context.Partner)
            .ReturnDataPagination();
    }

    public async Task<List<PartnerOutputModelDto>> GetAll(char status)
    {
        return await _context.Partner
            .AsNoTrackingWithIdentityResolution()
            .Where(x => x.Status == status)
            .Select(x => x.ConvertToObjectOutPut())
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<Partner> Exists(Partner entity)
    {
        return await _context.Partner
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.CnpjCpf == entity.CnpjCpf);
    }

    public async Task CreateList(IEnumerable<Partner> list)
    {
        foreach (var obj in list)
        { 
            _context.Partner.Add(obj);
        }
        await _context.SaveChangesAsync();
    }

    public async Task UpdateList(IEnumerable<Partner> list)
    {
        foreach (var dados in list)
        { 
            _context.Entry(dados).State = EntityState.Modified;
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteList(IEnumerable<Partner> list)
    {
        foreach (var obj in list)
        { 
            _context.Partner.Remove(obj);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<Partner> GetByCnpjCpf(string cnpjCpf)
    {
        return await _context.Partner
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.CnpjCpf == cnpjCpf);
    }

    public async Task<Partner> GetByCnpjCpfById(string cnpjCpf, Guid id)
    {
        return await _context.Partner
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.CnpjCpf == cnpjCpf && x.Id == id);
    }

    public async Task<Partner> GetByCorporateName(string corporateName)
    {
        return await _context.Partner
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.CorporateName == corporateName);
    }
}