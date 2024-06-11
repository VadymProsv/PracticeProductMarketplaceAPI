namespace ProductMarketplaceAPI
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(string id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(string id);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Order>> GetAllOrdersAsync() => await _repository.GetAllAsync();
        public async Task<Order> GetOrderByIdAsync(string id) => await _repository.GetByIdAsync(id);
        public async Task CreateOrderAsync(Order order) => await _repository.CreateAsync(order);
        public async Task UpdateOrderAsync(Order order) => await _repository.UpdateAsync(order);
        public async Task DeleteOrderAsync(string id) => await _repository.DeleteAsync(id);
    }

}
