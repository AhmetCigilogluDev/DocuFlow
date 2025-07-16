using DocuFlow.Application.DTO;

namespace DocuFlow.Application.Interfaces;

    public interface IDocumentService
    {
        Task<IEnumerable<DocumentDto>> GetAllAsync();
        Task<DocumentDto?> GetByIdAsync(Guid Id);
        Task AddAsync(DocumentDto dto);
        Task UpdateAsync(DocumentDto dto);
        Task DeleteAsync(Guid Id);

        Task<IEnumerable<DocumentDto>> GetByTagAsync(string tag);
        Task<IEnumerable<DocumentDto>> GetByUserAsync(string uploadBy);
        Task<IEnumerable<DocumentDto>> GetUnapprovedAsync();
    }
