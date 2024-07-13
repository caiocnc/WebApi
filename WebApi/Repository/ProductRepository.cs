using Microsoft.EntityFrameworkCore;
using WebApi.Config;
using WebApi.Entities;

namespace WebApi.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ContextBase _dbContext;
        public ProductRepository(ContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Product product)
        {
            await _dbContext.Set<Product>().AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {

            _dbContext.Set<Product>().Remove(product);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Product?> GetEntityById(int Id)
        {

            return await _dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == Id);

        }

        public async Task<List<Product>> List()
        {

            return await _dbContext.Set<Product>().ToListAsync();

        }

        public async Task Update(Product product)
        {

            _dbContext.Set<Product>().Update(product);
            await _dbContext.SaveChangesAsync();

        }
    }
}
