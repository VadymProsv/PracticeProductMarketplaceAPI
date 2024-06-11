using MongoDB.Driver;

namespace ProductMarketplaceAPI
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(string id);
        Task<User> GetByUsernameAsync(string username);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetAllAsync() => await _users.Find(_ => true).ToListAsync();
        public async Task<User> GetByIdAsync(string id) => await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(User user) => await _users.InsertOneAsync(user);
        public async Task UpdateAsync(User user) => await _users.ReplaceOneAsync(u => u.Id == user.Id, user);
        public async Task DeleteAsync(string id) => await _users.DeleteOneAsync(u => u.Id == id);
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
        }
    }

}
