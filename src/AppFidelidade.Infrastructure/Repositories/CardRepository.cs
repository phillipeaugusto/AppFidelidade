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
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _context;
        
        public CardRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Card entity)
        {
            _context.Card.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Card entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Card entity)
        {
            _context.Card.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<CardOutputModelDto> GetById(Guid id)
        {
            var obj = await _context.Card
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return obj?.ConvertToObjectOutPut();
        }

        public async Task<List<CardOutputModelDto>> GetAll()
        {
            return await _context.Card
                .AsNoTracking()
                .Select(x => x.ConvertToObjectOutPut())
                .ToListAsync();
        }

        public async Task<PaginationReturn<CardOutputModelDto>> GetAllPagination(PaginationParameters paginationParameters)
        {
            return await new PaginationReturnRepository<Card, CardOutputModelDto>(paginationParameters, _context.Card)
                .ReturnDataPagination();
        }

        public async Task<List<CardOutputModelDto>> GetAll(char status)
        {
            return await _context.Card
                .AsNoTracking()
                .Where(x => x.Status == status)
                .Select(x => x.ConvertToObjectOutPut())
                .ToListAsync();
        }

        public async Task<Card> Exists(Card entity)
        {
            return await _context.Card.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ClientId == entity.ClientId && x.CardNumber == entity.CardNumber);
        }

        public async Task CreateList(IEnumerable<Card> list)
        {
            foreach (var obj in list)
            {
                _context.Card.Add(obj);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateList(IEnumerable<Card> list)
        {
            foreach (var dados in list)
            {
                _context.Entry(dados).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteList(IEnumerable<Card> list)
        {
            foreach (var obj in list)
            {
                _context.Card.Remove(obj);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<CardOutputModelDto> GetCardByClientId(Guid clientId)
        {
            var obj = await _context.Card.AsNoTracking().FirstOrDefaultAsync(x => x.ClientId == clientId);
            return obj?.ConvertToObjectOutPut();
        }
    }
}