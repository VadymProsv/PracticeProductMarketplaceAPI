namespace ProductMarketplaceAPI
{
    public interface ISellerService
    {
        Task<List<Seller>> GetAllSellersAsync();
        Task<Seller> GetSellerByIdAsync(string id);
        Task CreateSellerAsync(Seller seller);
        Task UpdateSellerAsync(Seller seller);
        Task DeleteSellerAsync(string id);
    }

    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _repository;

        public SellerService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Seller>> GetAllSellersAsync() => await _repository.GetAllAsync();
        public async Task<Seller> GetSellerByIdAsync(string id) => await _repository.GetByIdAsync(id);
        public async Task CreateSellerAsync(Seller seller) => await _repository.CreateAsync(seller);
        public async Task UpdateSellerAsync(Seller seller) => await _repository.UpdateAsync(seller);
        public async Task DeleteSellerAsync(string id) => await _repository.DeleteAsync(id);
    }

}
