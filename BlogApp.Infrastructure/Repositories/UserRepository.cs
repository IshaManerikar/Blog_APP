using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly BlogAppDbContext _context;

    public UserRepository(BlogAppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}