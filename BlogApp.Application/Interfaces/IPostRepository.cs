using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Interfaces
{
    public interface IPostRepository
    {
        public Task<List<Post>> GetAllAsync();
        public Task<Post?> GetByIdAsync(int id);
        public Task AddAsync(Post post);
        public Task UpdateAsync(Post post);
        public Task DeleteAsync(Post post);

    }
}
