namespace ProductMarketplaceAPI
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
        Task<User> AuthenticateAsync(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> GetAllUsersAsync() => await _repository.GetAllAsync();
        public async Task<User> GetUserByIdAsync(string id) => await _repository.GetByIdAsync(id);
        public async Task CreateUserAsync(User user) => await _repository.CreateAsync(user);
        public async Task UpdateUserAsync(User user) => await _repository.UpdateAsync(user);
        public async Task DeleteUserAsync(string id) => await _repository.DeleteAsync(id);

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _repository.GetByUsernameAsync(username);
            if (user == null || user.Password != password)
            {
                return null;
            }
            return user;
        }

    }

}
