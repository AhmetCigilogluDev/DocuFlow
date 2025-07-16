using DocuFlow.Application.DTO;

namespace DocuFlow.Application.Interfaces
{
    public interface IFolderService
    {
        //  GetAllAsync()(Task<IEnumerable<FolderDto>>), GetByAsync(Guid id)(Task<FoldeeDto?)

        Task<IEnumerable<FolderDto>> GetAllAsync();
        Task<FolderDto?> GetByIdAsync(Guid id);
        Task AddAsync(FolderDto dto);
        Task UpdateAsync(FolderDto dto);
        Task DeleteAsync(Guid id);
    }
}