using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AppFidelidade.Domain.Pagination;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static System.Decimal;

namespace AppFidelidade.Infrastructure.Repositories.Pagination;

[ExcludeFromCodeCoverage]
public class PaginationReturnRepository<TSource, TDestiny> where TSource : class 
{
    const decimal RoundingValue = (decimal) 0.1;
    private static Mapper _mapperTDestiny;
    private readonly PaginationParameters _paginationParameters;
    private readonly DbSet<TSource> _dbSet;

    private int CalculateCountPage(int recordCount, int pageSize)
    {
        var result = (decimal) recordCount / pageSize;
        var fraction = result - Truncate(result);

        if (fraction >= RoundingValue)
            result += 1;

        return (int) result;
    }
    public PaginationReturnRepository(PaginationParameters paginationParameters, DbSet<TSource> dbSet)
    {
        _paginationParameters = paginationParameters;
        _dbSet = dbSet;
            
        var mapperConfiguration = new MapperConfiguration(cfg =>
            cfg.CreateMap<TSource, TDestiny>()
        );

        _mapperTDestiny = new Mapper(mapperConfiguration);
    }

    private static TDestiny ConvertToObjectOutPut(TSource source) => _mapperTDestiny.Map<TDestiny>(source);

    public async Task<PaginationReturn<TDestiny>> ReturnDataPagination()
    {
        var pagedData = await _dbSet
            .AsNoTracking()
            .Skip((_paginationParameters.PageNumber - 1) * _paginationParameters.PageSize)
            .Take(_paginationParameters.PageSize)
            .Select(x => ConvertToObjectOutPut(x))
            .ToListAsync();

        var recordCount = _dbSet.Count();
        var pagesRemaining = CalculateCountPage(recordCount, _paginationParameters.PageSize); 
            
        return new PaginationReturn<TDestiny>(_paginationParameters.PageNumber, _paginationParameters.PageSize, recordCount , pagedData, pagesRemaining);
    }
}