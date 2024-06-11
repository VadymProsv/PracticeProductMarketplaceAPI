using MongoDB.Driver;

namespace ProductMarketplaceAPI
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(string id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(IMongoDatabase database)
        {
            _products = database.GetCollection<Product>("Products");
        }

        public async Task<List<Product>> GetAllAsync() => await _products.Find(_ => true).ToListAsync();
        public async Task<Product> GetByIdAsync(string id) => await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Product product) => await _products.InsertOneAsync(product);
        public async Task UpdateAsync(Product product) => await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
        public async Task DeleteAsync(string id) => await _products.DeleteOneAsync(p => p.Id == id);
    }

}
