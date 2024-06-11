using MongoDB.Driver;
using ProductMarketplaceAPI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITestService
{
    Task<User> AuthenticateAsync(string username, string password);
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetByUsernameAsync(string username);
}
public class TestService : ITestService
{
    private readonly IMongoCollection<User> _users;

    public TestService(IMongoClient client)
    {
        var database = client.GetDatabase("GroceryMarketplaceDB");
        _users = database.GetCollection<User>("Users");
    }

    public async Task<User> AuthenticateAsync(string username, string password)
    {
        var user = await GetByUsernameAsync(username);
        if (user == null || user.Password != password)
        {
            return null;
        }
        return user;
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
    }

    // Метод для отримання всіх користувачів
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _users.Find(_ => true).ToListAsync();
    }
}