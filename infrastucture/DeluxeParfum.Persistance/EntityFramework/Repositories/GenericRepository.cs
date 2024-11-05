using DeluxeParfum.Application.Interfaces;
using DeluxeParfum.Domain.Entities.Common;
using DeluxeParfum.Persistance.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Persistance.EntityFramework.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DeluxeParfumContext _dbcontext;
        protected DbSet<T> Table => _dbcontext.Set<T>();

        public GenericRepository(DeluxeParfumContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> AddAsync(T entity)
        {
            var addedState = await Table.AddAsync(entity);
            return addedState.State == EntityState.Added;
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool tracking = true)
        {
            if (tracking is false)
            {
                return await Table.AsNoTracking().ToListAsync();
            }
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await Table.FindAsync(id);

        public async Task<List<T>> GetWhere(Expression<Func<T, bool>> expression)
              => await Table.Where(expression).ToListAsync();


        public bool Remove(T entity)
        {
            var removed = Table.Remove(entity);
            return removed.State == EntityState.Deleted;
        }

        public bool Update(T entity)
        {
            var updated = Table.Update(entity);
            return updated.State == EntityState.Modified;
        }

    }
}
