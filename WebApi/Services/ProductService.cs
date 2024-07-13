using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public Task Add(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
