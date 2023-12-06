﻿using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Domain.Common;
using Derivco.GameRoulette.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DerivcoDatabaseContext _context;

        public GenericRepository(DerivcoDatabaseContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
