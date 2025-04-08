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

    public async Task<User?> GetUserByUsername(string username)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(data=>data.Username == username);
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
}