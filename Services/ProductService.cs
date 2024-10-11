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

public class ProductService : IProductRepository
{   
    private readonly ApplicationDbContext _context;
    
    public async Task<bool> CheckExistence(int id)
    {
        {
            try
            {
                return await _context.Products.AnyAsync(x => x.Id == id);
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException("Error occurred while checking if The booking exists", e);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while checking if The booking exists", ex);
            }
        }
    }

    public Task<ProductDTO> Create(ProductDTO productDTO)
    {
        try
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return Task.FromResult(new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Error occurred while creating The product", e);
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while creating The product", ex);
        }
        
    }

    public async Task Delete(int id)
    {
        try
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Error occurred while deleting The product", e);
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while deleting The product", ex);
        }
        
    }

    public async Task<IEnumerable<ProductDTO>> GetAll()
    {
        return await _context.Products
            .Select(x => new ProductDTO
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            })
            .ToListAsync();
    }

    public async Task<ProductDTO> GetbyId(int id)
    {
        var product = _context.Products
            .Where(x => x.Id == id)
            .Select(x => new ProductDTO
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            })
            .FirstOrDefaultAsync();
        return await product;
    }

    public async Task<ProductDTO> Update(int id,ProductDTO productDTO)
    {
        var product = _context.Products
            .Where(x => x.Id == productDTO.Id)
            .Select(x => new ProductDTO
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            })
            .FirstOrDefaultAsync();
        return await product;
    }
}
