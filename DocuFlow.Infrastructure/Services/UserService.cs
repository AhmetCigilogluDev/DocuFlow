using DocuFlow.Application.DTO;
using DocuFlow.Application.Interfaces;
using DocuFlow.Domain.Entities;
using DocuFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DocuFlow.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public UserService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string?> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return null;

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return GenerateJwt(user);
        }

        public async Task<List<UserDto>> GetAllAsync()
{
    var users = await _context.Users.ToListAsync();
    return users.Select(u => new UserDto
    {
        Id = u.Id,
        UserName = u.UserName,
        Email = u.Email,
        Role = u.Role
    }).ToList();
}

public async Task<UserDto?> GetByIdAsync(Guid id)
{
    var user = await _context.Users.FindAsync(id);
    if (user == null) return null;

    return new UserDto
    {
        Id = user.Id,
        UserName = user.UserName,
        Email = user.Email,
        Role = user.Role
    };
}

public async Task<bool> DeleteAsync(Guid id)
{
    var user = await _context.Users.FindAsync(id);
    if (user == null) return false;

    _context.Users.Remove(user);
    await _context.SaveChangesAsync();
    return true;
}

public async Task<bool> UpdateAsync(Guid id, UpdateUserDto dto)
{
    var user = await _context.Users.FindAsync(id);
    if (user == null) return false;

    user.UserName = dto.UserName;
    user.Email = dto.Email;
    user.Role = dto.Role;

    _context.Users.Update(user);
    await _context.SaveChangesAsync();
    return true;
}


        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            return GenerateJwt(user);
        }

        private string GenerateJwt(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
