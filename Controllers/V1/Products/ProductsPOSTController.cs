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
    public class ProductsPOSTController : ProductsController
    {
        public ProductsPOSTController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO productDTO)
        {
            await services.Create(productDTO);
            return Created("", productDTO);
        }
    }
}