using MongoDB.Driver;

namespace ProductMarketplaceAPI
{
    public interface ISellerRepository
    {
        Task<List<Seller>> GetAllAsync();
        Task<Seller> GetByIdAsync(string id);
        Task CreateAsync(Seller seller);
        Task UpdateAsync(Seller seller);
        Task DeleteAsync(string id);
    }

    public class SellerRepository : ISellerRepository
    {
        private readonly IMongoCollection<Seller> _sellers;

        public SellerRepository(IMongoDatabase database)
        {
            _sellers = database.GetCollection<Seller>("Sellers");
        }

        public async Task<List<Seller>> GetAllAsync() => await _sellers.Find(_ => true).ToListAsync();
        public async Task<Seller> GetByIdAsync(string id) => await _sellers.Find(s => s.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Seller seller) => await _sellers.InsertOneAsync(seller);
        public async Task UpdateAsync(Seller seller) => await _sellers.ReplaceOneAsync(s => s.Id == seller.Id, seller);
        public async Task DeleteAsync(string id) => await _sellers.DeleteOneAsync(s => s.Id == id);
    }

}
