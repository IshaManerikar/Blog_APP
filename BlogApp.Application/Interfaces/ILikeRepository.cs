using BlogApp.Domain.Entities;

public interface ILikeRepository
{
    Task AddAsync(Like like);
    Task RemoveAsync(Like like);

    Task<Like?> GetByPostAndUserAsync(int postId, int userId);

    Task<List<Like>> GetByPostIdAsync(int postId);

    Task<int> GetLikeCountAsync(int postId);

    Task SaveChangesAsync();
}