using BlogApp.Application.DTOs.Post;
using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Services
{
    public class PostService
    {
        private readonly IPostRepository _repo;

        public PostService(IPostRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<PostResponseDto>> GetAllAsync()
        {
            var posts = await _repo.GetAllAsync();
            return posts.Select(p => new PostResponseDto
            {
                PostId = p.PostId,
                Title = p.Title,
                Content = p.Content,
                CategoryId = p.CategoryId
            }).ToList();

        }
        public async Task<PostResponseDto> GetByIdAsync(int id)
        {
            var post = await _repo.GetByIdAsync(id);
            if (post == null)
                throw new Exception("Post not found");
            return new PostResponseDto
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId
            };
        }
        public async Task CreateAsync(CreatePostDto dto)
        {
            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                CategoryId = dto.CategoryId,

                UserId = 1
            };
            await _repo.AddAsync(post);
        }

        public async Task UpdateAsync(int id, UpdatePostDto dto)
        {
            var post = await _repo.GetByIdAsync(id);
            if (post == null)
                throw new Exception("Post not found");
            post.Title = dto.Title;
            post.Content = dto.Content;
            post.CategoryId = dto.CategoryId;
            post.UpdatedAt = DateTime.UtcNow;
            post.UserId = 1;
            await _repo.UpdateAsync(post);
        }

        public async Task DeleteAsync(int id)
        {
            var post = await _repo.GetByIdAsync(id);
            if (post == null)
                throw new Exception("Post not found");
            await _repo.DeleteAsync(post);
        }
    }
}
