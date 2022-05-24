using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFidelidade.Domain.Pagination;

namespace AppFidelidade.Domain.Repositories.Contracts;

public interface IRepository<TEntity, TDtoOutPutModel>
{
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task<TDtoOutPutModel> GetById(Guid id);
    Task<List<TDtoOutPutModel>> GetAll();
    Task<PaginationReturn<TDtoOutPutModel>> GetAllPagination(PaginationParameters paginationParameters);
    Task<List<TDtoOutPutModel>> GetAll(char status);
    Task<TEntity> Exists(TEntity entity);
    Task CreateList(IEnumerable<TEntity> list);
    Task UpdateList(IEnumerable<TEntity> list);
    Task DeleteList(IEnumerable<TEntity> list);
}