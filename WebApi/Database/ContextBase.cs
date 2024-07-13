using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Database.Map;
using WebApi.Entities;

namespace WebApi.Config
{
    public class ContextBase : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseIdentityColumns();
            base.OnModelCreating(builder);
            new ProductMap().Configure(builder.Entity<Product>())
        }
               
    }
}
