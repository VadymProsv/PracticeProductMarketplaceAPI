namespace ProductMarketplaceAPI
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(string id);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllProductsAsync() => await _repository.GetAllAsync();
        public async Task<Product> GetProductByIdAsync(string id) => await _repository.GetByIdAsync(id);
        public async Task CreateProductAsync(Product product) => await _repository.CreateAsync(product);
        public async Task UpdateProductAsync(Product product) => await _repository.UpdateAsync(product);
        public async Task DeleteProductAsync(string id) => await _repository.DeleteAsync(id);
    }

}
