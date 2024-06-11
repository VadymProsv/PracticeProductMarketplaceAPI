using MongoDB.Driver;

namespace ProductMarketplaceAPI
{
    public interface IRegisteredClientRepository
    {
        Task<List<RegisteredClient>> GetAllAsync();
        Task<RegisteredClient> GetByIdAsync(string id);
        Task CreateAsync(RegisteredClient client);
        Task UpdateAsync(RegisteredClient client);
        Task DeleteAsync(string id);
    }

    public class RegisteredClientRepository : IRegisteredClientRepository
    {
        private readonly IMongoCollection<RegisteredClient> _clients;

        public RegisteredClientRepository(IMongoDatabase database)
        {
            _clients = database.GetCollection<RegisteredClient>("RegisteredClients");
        }

        public async Task<List<RegisteredClient>> GetAllAsync() => await _clients.Find(_ => true).ToListAsync();
        public async Task<RegisteredClient> GetByIdAsync(string id) => await _clients.Find(c => c.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(RegisteredClient client) => await _clients.InsertOneAsync(client);
        public async Task UpdateAsync(RegisteredClient client) => await _clients.ReplaceOneAsync(c => c.Id == client.Id, client);
        public async Task DeleteAsync(string id) => await _clients.DeleteOneAsync(c => c.Id == id);
    }

}
