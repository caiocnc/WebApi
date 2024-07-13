using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Repository;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("/api/List")]
        [Produces("application/json")]
        public async Task<object> List()
        {
            return await _productService.List();
        }
        
        [HttpPost("/api/Add")]
        [Produces("application/json")]
        public async Task<object> Add(ProductDto product)
        {
            try
            {
                await _productService.Add(product);
            }
            catch (Exception ERRO)
            {

            }

            return Task.FromResult("OK");
        }

        [HttpPut("/api/Update")]
        [Produces("application/json")]
        public async Task<object> Update(ProductDto product)
        {
            try
            {
                await _productService.Update(product);
            }
            catch (Exception ERRO)
            {

            }

            return Task.FromResult("OK");
        }


        [HttpGet("/api/GetEntityById")]
        [Produces("application/json")]
        public async Task<object> GetEntityById(int id)
        {
            return await _productService.GetEntityById(id);
        }

        [HttpDelete("/api/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var product = await _productService.GetEntityById(id);

                await _productService.Delete(product);

            }
            catch (Exception ERRO)
            {
                return false;
            }

            return true;

        }
    }
}
