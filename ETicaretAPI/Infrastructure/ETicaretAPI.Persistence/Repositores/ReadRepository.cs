using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositores
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretDbcontext _context;
        public ReadRepository(ETicaretDbcontext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        //=> Table;       //buradaki Table DbSet-den gelir. Tabledeki butun datani Get etmek ucundur.
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        //=> await Table.FindAsync(id);
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(method);
        {
            var query = Table.AsNoTracking();
            if(!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        //=> Table.Where(method);
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
