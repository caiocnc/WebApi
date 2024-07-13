using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Services
{
    public interface IProductService
    {
        Task Add(ProductDto product);
        Task Update(ProductDto product);
    }
}
