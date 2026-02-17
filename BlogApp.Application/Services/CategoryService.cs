using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CategoryService
{
    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<CategoryResponseDto>> GetAllAsync()
    {
        var categories = await _repo.GetAllAsync();

        return categories.Select(c => new CategoryResponseDto
        {
            CategoryId = c.CategoryId,
            Name = c.Name
        }).ToList();
    }

    public async Task CreateAsync(CreateCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name
        };

        await _repo.AddAsync(category);
    }

    public async Task UpdateAsync(int id, UpdateCategoryDto dto)
    {
        var category = await _repo.GetByIdAsync(id);

        if (category == null)
            throw new Exception("Category not found");

        category.Name = dto.Name;

        await _repo.UpdateAsync(category);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _repo.GetByIdAsync(id);

        if (category == null)
            throw new Exception("Category not found");

        await _repo.DeleteAsync(category);
    }
}

