using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync(string? searchString);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}