using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProducts.DTO;

namespace ApiProducts.Repositories;

public interface IProductRepository
{

    Task<IEnumerable<ProductDTO>> GetAll();

    Task<ProductDTO> GetbyId(int id);

    Task<ProductDTO> Create(ProductDTO productDTO);

    Task<ProductDTO> Update(int id, ProductDTO productDTO);

    Task Delete(int id);

    Task<bool> CheckExistence(int id);

}
