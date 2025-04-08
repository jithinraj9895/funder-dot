using jwt_funder.Core.Data;
using jwt_funder.Core.Interfaces;
using jwt_funder.Models;
using Microsoft.EntityFrameworkCore;

namespace jwt_funder.Core.Repositories;

public class FunderRepository(FunderContext context) : IFunderRepository
{

    private readonly FunderContext _context = context;

    public Task AddUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
}