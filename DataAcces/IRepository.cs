using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAcces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T model);
        Task Delete(T model);
        Task<IQueryable<T>> Get(int id, params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task Update(T model);
    }
}