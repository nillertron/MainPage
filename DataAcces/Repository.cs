using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class Repository<T> : IRepository<T> where T : class, BaseModel
    {
        protected DbSet<T> table;
        protected MysqlDbContext dbContext;
        public Repository(MysqlDbContext context)
        {
            dbContext = context;
            table = context.Set<T>();


        }
        public async Task Create(T model)
        {
            await table.AddAsync(model);
            await dbContext.SaveChangesAsync();

        }
        public async Task Update(T model)
        {
            table.Update(model);
            await dbContext.SaveChangesAsync();
        }
        public async Task Delete(T model)
        {
            dbContext.Remove(model);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = null;
            foreach (var includeExpression in includes)
            {
                query = table.Include(includeExpression);
            }

            return query ?? table;
        }
        public async Task<IQueryable<T>> Get(int id, params Expression<Func<T,object>>[] includes)
        {
            IQueryable<T> query = table.Where(x=>x.Id == id);
            foreach(var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
