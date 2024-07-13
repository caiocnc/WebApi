using WebApi.Entities;

namespace WebApi.Repository
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
        Task<Product?> GetEntityById(int Id);
        Task<List<Product>> List();
    }
}
