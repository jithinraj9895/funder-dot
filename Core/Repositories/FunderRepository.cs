using jwt_funder.Core.Data;
using jwt_funder.Core.Interfaces;
using jwt_funder.Models;
using jwt_funder.Models.Dto;
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

    public async Task<List<BestIdeasDto>> GetTopIdeasAsync()
    {
        return await _context.Ideas.OrderByDescending(i => i.Approvals - i.Disapprovals).Take(10).
            Select(i => new BestIdeasDto(i.Title,i.Description)).ToListAsync();
    }

    public async Task<List<Idea>> GetAllIdeasAsync()
    {
        return await _context.Ideas.OrderByDescending(i => i.CreatedDate).ToListAsync();
    }
}