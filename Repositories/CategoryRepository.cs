using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProducts.DTO;

namespace ApiProducts.Repositories;

public interface CategoryRepository
{
    Task<IEnumerable<CategoryDTO>> GetAll();

    Task<CategoryDTO> GetbyId(int id);

    Task<CategoryDTO> Create(CategoryDTO categoryDTO);

    Task<CategoryDTO> Update(int id, CategoryDTO categoryDTO);

    Task Delete(int id);

    Task<bool> CheckExistence(int id);

}
