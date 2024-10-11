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
    public class ProductsPUTController : ProductsController
    {
        public ProductsPUTController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            await services.Update(id, productDTO);
            return NoContent();
        }
    }
}