using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProducts.DTO;
using ApiProducts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiProducts.Controllers.V1.Products
{
    [ApiController]
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Products")]
    public class ProductsGETController : ProductsController
    {
        public ProductsGETController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return await services.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ProductDTO> GetbyId(int id)
        {
            return await services.GetbyId(id);
        }
    }
}