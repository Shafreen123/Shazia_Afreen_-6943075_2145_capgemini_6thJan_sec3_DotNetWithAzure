using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId))
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetAllWithCategoriesAsync()
{
    return await _context.Products
        .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
        .ToListAsync();
}

public async Task<Product?> GetProductWithCategoriesAsync(int id)
{
    return await _context.Products
        .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
        .FirstOrDefaultAsync(p => p.Id == id);
}

        public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword)
        {
            return await _context.Products
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .Where(p => p.Name.Contains(keyword) ||
                            p.Description.Contains(keyword))
                .ToListAsync();
        }
    }
}