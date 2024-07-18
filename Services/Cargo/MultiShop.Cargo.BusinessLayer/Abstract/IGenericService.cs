using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<T> TGetByIdAsync(int id);
        Task<T> TGetAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> TGetAllAsync();
        Task TAddAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(int id);
    }
}
