using jwt_funder.Models;
using jwt_funder.Models.Dto;

namespace jwt_funder.Core.Interfaces;

public interface IFunderRepository
{
    public Task AddUserAsync(User user);
    public Task<User?> GetUserByUsername(string email);
    
    public Task<List<User>> GetUsersAsync();
    
    public Task<List<BestIdeasDto>> GetTopIdeasAsync();
    public Task<List<Idea>> GetAllIdeasAsync();
}