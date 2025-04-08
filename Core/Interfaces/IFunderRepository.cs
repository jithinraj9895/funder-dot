using jwt_funder.Models;

namespace jwt_funder.Core.Interfaces;

public interface IFunderRepository
{
    public Task AddUserAsync(User user);
    public Task<User?> GetUserByEmailAsync(string email);
    
    public Task<List<User>> GetUsersAsync();
}