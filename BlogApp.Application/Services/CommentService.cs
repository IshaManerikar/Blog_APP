using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BlogApp.Application.DTOs;
using BlogApp.Application.DTOs.Comment;
using BlogApp.Domain.Entities;
public class CommentService

    {
    private readonly ICommentRepository _repo;

    public CommentService(ICommentRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<CommentResponseDto>> GetAllAsync()
    {
        var comments = await _repo.GetAllAsync();
        return comments.Select(c => new CommentResponseDto
        {
            CommentId = c.CommentId,
            Content = c.Content,
            PostId = c.PostId
        }).ToList();
    }

    public async Task CreateAsync(CreateCommentDto dto)
    {
        var comment = new Comment
        {
            Content = dto.Content,
            PostId = dto.PostId,
            UserId = 1
        };
        await _repo.AddAsync(comment);
    }

    public async Task UpdateAsync(int id, UpdateCommentDto dto)
    {
        var comment = await _repo.GetByIdAsync(id);
        if (comment == null)
            throw new Exception("Comment not found");
        comment.Content = dto.Content;
        comment.UserId = 1;
        await _repo.UpdateAsync(comment);
    }

    public async Task DeleteAsync(int id)
    {
        var comment = await _repo.GetByIdAsync(id);
        if (comment == null)
            throw new Exception("Comment not found");
        await _repo.DeleteAsync(comment);
    }
}

