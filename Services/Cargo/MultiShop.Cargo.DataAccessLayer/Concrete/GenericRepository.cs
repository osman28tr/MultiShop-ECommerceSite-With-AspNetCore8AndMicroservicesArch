using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        private readonly CargoContext _context;
        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(value);
            await _context.SaveChangesAsync();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(Func<T, bool> predicate)
        {
            var value = await _context.Set<T>().FindAsync(predicate);
            return value;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);
            return value;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
