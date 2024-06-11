using MongoDB.Driver;

namespace ProductMarketplaceAPI
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(string id);
        Task CreateAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(string id);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderRepository(IMongoDatabase database)
        {
            _orders = database.GetCollection<Order>("Orders");
        }

        public async Task<List<Order>> GetAllAsync() => await _orders.Find(_ => true).ToListAsync();
        public async Task<Order> GetByIdAsync(string id) => await _orders.Find(o => o.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Order order) => await _orders.InsertOneAsync(order);
        public async Task UpdateAsync(Order order) => await _orders.ReplaceOneAsync(o => o.Id == order.Id, order);
        public async Task DeleteAsync(string id) => await _orders.DeleteOneAsync(o => o.Id == id);
    }

}
