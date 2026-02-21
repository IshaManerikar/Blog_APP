using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BlogApp.Application.Interfaces;
public class LikeRepository : ILikeRepository
{
    private readonly BlogAppDbContext _context;

    public LikeRepository(BlogAppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Like like)
    {
        await _context.Likes.AddAsync(like);
    }

    public async Task RemoveAsync(Like like)
    {
        _context.Likes.Remove(like);
        await Task.CompletedTask;
    }

    public async Task<Like?> GetByPostAndUserAsync(int postId, int userId)
    {
        return await _context.Likes
            .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
    }

    public async Task<List<Like>> GetByPostIdAsync(int postId)
    {
        return await _context.Likes
            .Where(l => l.PostId == postId)
            .ToListAsync();
    }

    public async Task<int> GetLikeCountAsync(int postId)
    {
        return await _context.Likes
            .CountAsync(l => l.PostId == postId);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}