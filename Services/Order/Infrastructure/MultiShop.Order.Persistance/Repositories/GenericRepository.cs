using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Persistance.Contexts;

namespace MultiShop.Order.Persistance.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly MultiShopOrderContext _context;
        public GenericRepository(MultiShopOrderContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            var entities = filter == null ? await _context.Set<T>().ToListAsync() : await _context.Set<T>().Where(filter).ToListAsync();
            return entities;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(filter);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntity = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var updatedEntity = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            var deletedEntity = _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return deletedEntity.Entity;
        }
    }
}
