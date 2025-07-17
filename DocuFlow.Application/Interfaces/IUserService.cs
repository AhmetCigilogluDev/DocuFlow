using DocuFlow.Application.DTO;
namespace DocuFlow.Application.Interfaces
{
    public interface IUserService
    {
        Task<string?> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);

    // Yeni eklenen CRUD işlemleri:
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, UpdateUserDto dto);
}
}
