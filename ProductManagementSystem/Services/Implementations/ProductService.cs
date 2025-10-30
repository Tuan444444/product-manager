

namespace ProductManagementSystem.Services.Implementations

{
    using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories.Interfaces;
using ProductManagementSystem.Services.Interfaces;
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        // Tiêm IProductRepository vào (Dependency Injection)
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            // (Ví dụ Business Logic: có thể thêm kiểm tra logic phức tạp ở đây)
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            // (Ví dụ Business Logic)
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}