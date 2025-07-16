using DocuFlow.Domain.Entities;

namespace DocuFlow.Domain.Interfaces
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAllAsync();
        Task<Document?> GetByIdAsync(Guid Id);
        Task AddAsync(Document document);
        Task UpdateAsync(Document document);
        Task DeleteAsync(Document document);

        Task<IEnumerable<Document>> GetByTagAsync(string tag);
        Task<IEnumerable<Document>> GetByUserAsync(string uploadBy);
        Task<IEnumerable<Document>> GetUnapprovedAsync();
    }
}