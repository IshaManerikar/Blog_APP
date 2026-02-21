using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlogApp.Application.Services
{
    public class LikeService
    {
        private readonly ILikeRepository _repo;

        public LikeService(ILikeRepository repo)
        {
            _repo = repo;
        }

        public async Task LikePostAsync(int postId, int userId)
        {
            var like = await _repo.GetByPostAndUserAsync(postId, userId);
            if (like != null)
                throw new Exception("Already liked");
            like = new Domain.Entities.Like
            {
                PostId = postId,
                UserId = userId
            };
            await _repo.AddAsync(like);
            await _repo.SaveChangesAsync();
        }

        public async Task UnlikePostAsync(int postId, int userId)
        {
            var like = await _repo.GetByPostAndUserAsync(postId, userId);

            if (like == null)
                throw new Exception("Like not found");

            await _repo.RemoveAsync(like);
            await _repo.SaveChangesAsync();
        }
        public async Task<List<Like>> GetAllLikesByPostAsync(int postId)
        {
            return await _repo.GetByPostIdAsync(postId);
        }

        public async Task<int> GetLikeCountAsync(int postId)
        {
            return await _repo.GetLikeCountAsync(postId);
        }

    }
}
