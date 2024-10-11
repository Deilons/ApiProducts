using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProducts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiProducts.Controllers.V1.Products
{
    [ApiController]
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Products")]
    public class ProductsDELETEController : ProductsController
    {
        public ProductsDELETEController(IProductRepository productRepository) : base(productRepository)
        {
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await services.Delete(id);
            return NoContent();
        }
    }
}