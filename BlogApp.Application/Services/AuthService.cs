using BlogApp.Application.DTOs;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Interfaces;
using BlogApp.Application.Services;
using BlogApp.Domain.Entities;
using BlogApp.Application.Exceptions;
public class AuthService
{
    private readonly IUserRepository _repo;
    private readonly PasswordService _passwordService;

    public AuthService(IUserRepository repo, PasswordService passwordService)
    {
        _repo = repo;
        _passwordService = passwordService;
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var existing = await _repo.GetByEmailAsync(dto.Email);
        if (existing != null)
            throw new BadRequestException("Email already exists");

        var user = new User
        {
            Username = dto.UserName,
            Email = dto.Email,
            Role = "Reader",
            PasswordHash = _passwordService.HashPassword(dto.Password)
        };

        await _repo.AddAsync(user);
        await _repo.SaveChangesAsync();
    }


    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _repo.GetByEmailAsync(dto.Email);

        if (user == null)
            throw new UnauthorizedException("Invalid email!");

        var isValid = _passwordService.Verify(dto.Password, user.PasswordHash);

        if (!isValid)
            throw new UnauthorizedException("Invalid password!");

        return "Login successful";
    }
}