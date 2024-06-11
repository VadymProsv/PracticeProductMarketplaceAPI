namespace ProductMarketplaceAPI
{
    public interface IRegisteredClientService
    {
        Task<List<RegisteredClient>> GetAllClientsAsync();
        Task<RegisteredClient> GetClientByIdAsync(string id);
        Task CreateClientAsync(RegisteredClient client);
        Task UpdateClientAsync(RegisteredClient client);
        Task DeleteClientAsync(string id);
    }

    public class RegisteredClientService : IRegisteredClientService
    {
        private readonly IRegisteredClientRepository _repository;

        public RegisteredClientService(IRegisteredClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RegisteredClient>> GetAllClientsAsync() => await _repository.GetAllAsync();
        public async Task<RegisteredClient> GetClientByIdAsync(string id) => await _repository.GetByIdAsync(id);
        public async Task CreateClientAsync(RegisteredClient client) => await _repository.CreateAsync(client);
        public async Task UpdateClientAsync(RegisteredClient client) => await _repository.UpdateAsync(client);
        public async Task DeleteClientAsync(string id) => await _repository.DeleteAsync(id);
    }

}
