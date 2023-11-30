using Firplak.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Firplak.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Base
    {

        private DbSet<T> _entityBase;
        private LogisticaFirplackBDContext _context;

        public GenericRepository(LogisticaFirplackBDContext context)
        {
            _entityBase = context.Set<T>();
            _context = context;
        }

        public async Task<bool> Insert(T entity)
        {
            await _entityBase.AddAsync(entity);
            await _context.SaveChangesAsync(true);
            return true;
        }

        public async Task<T> Get(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> Query = _context.Set<T>();
            Query = Query.Where(condition);
            return await Query.FirstOrDefaultAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _entityBase.Update(entity);
            await _context.SaveChangesAsync(true);
            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            _entityBase.Remove(entity);
            await _context.SaveChangesAsync(true);
            return true;
        }

        public IQueryable<T> List(Expression<Func<T, bool>>? Condicion)
        {
            IQueryable<T> Query = _context.Set<T>();
            if (Condicion != null)
            {
                Query = Query.Where(Condicion);
            }

            return Query;
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>>? Condicion)
        {
            IQueryable<T> Query = List(Condicion);
            return await Query.ToListAsync().ConfigureAwait(false);
        }

        public bool Execute(string SQL)
        {
            _context.Database.ExecuteSqlRaw(SQL);
            _context.SaveChanges();
            return true;
        }

    }
}
