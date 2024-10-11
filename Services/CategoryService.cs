using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProducts.Data;
using ApiProducts.DTO;
using ApiProducts.Models;
using ApiProducts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiProducts.Services;

public class CategoryService : CategoryRepository
{
    private readonly ApplicationDbContext _context;

    public async Task<bool> CheckExistence(int id)
    {
        try
        {
            return await _context.Categories.AnyAsync(x => x.Id == id);
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Error occurred while checking if The category exists", e);
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while checking if The category exists", ex);
        }
    }

    public async Task<CategoryDTO> Create(CategoryDTO categoryDTO)
    {
        try
        {
            var category = new Category
            {
                Name = categoryDTO.Name
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return await Task.FromResult(new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            }); 
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Error occurred while creating The category", e);
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while creating The category", ex);
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Error occurred while deleting The category", e);
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while deleting The category", ex);
        }
    }

    public async Task<IEnumerable<CategoryDTO>> GetAll()
    {
        try
        {
            return await _context.Categories
            .Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            })
            .ToListAsync();
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Error occurred while getting All categories", e);
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while getting All categories", ex);
        }
    }

    public async Task<CategoryDTO?> GetbyId(int id)
    {
        try
        {
            return await _context.Categories
            .Where(x => x.Id == id)
            .Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            })
            .FirstOrDefaultAsync();
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Error occurred while getting The category", e);
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while getting The category", ex);
        }
    }

    public async Task<CategoryDTO> Update(int id, CategoryDTO categoryDTO)
    {
        try
        {
            var category = _context.Categories
            .Where(x => x.Id == id)
            .Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            })
            .FirstOrDefaultAsync();
            return await category;
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Error occurred while updating The category", e);
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while updating The category", ex);
        }
    }
}
