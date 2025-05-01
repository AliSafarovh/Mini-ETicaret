using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretDbcontext:DbContext
    {
        public ETicaretDbcontext(DbContextOptions<ETicaretDbcontext> options)
            : base(options) { }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<Order> Orders { get; set; }
        public  DbSet<Customer> Customers { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>(); //BaseEntityde bir deyisiklik olsa bunu datasda saxla.
            foreach (var data in datas) //hemin deyisiklikleri foreach ile yoxla
            {
                _ = data.State switch //switch ile yoxla
                {
                    EntityState.Added=>data.Entity.CreatedDate=DateTime.UtcNow,
                    EntityState.Modified=>data.Entity.UpdatedDate=DateTime.UtcNow,
                    _=>DateTime.UtcNow  //Eger hec biri olmazsa, burani dondur.
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
