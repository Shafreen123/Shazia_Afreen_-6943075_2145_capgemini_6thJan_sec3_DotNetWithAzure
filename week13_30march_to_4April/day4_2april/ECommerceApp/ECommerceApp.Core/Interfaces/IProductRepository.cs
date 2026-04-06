using ECommerceApp.Core.Entities;

namespace ECommerceApp.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> SearchProductsAsync(string keyword);
        Task<IEnumerable<Product>> GetAllWithCategoriesAsync();      // ✅ NEW
        Task<Product?> GetProductWithCategoriesAsync(int id); 
    }
}