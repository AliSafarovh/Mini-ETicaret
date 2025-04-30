using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositores
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ETicaretDbcontext _context;
        public WriteRepository(ETicaretDbcontext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>(); //Db-da T- tipine uygun gelen Table-i alir

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Delete(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            T model = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return Delete(model);
        }

        public bool DeleteRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }
        public bool Update(T model)
        {
            EntityEntry entityEntry= Table.Update(model);
            return entityEntry.State==EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();   

    }
}
