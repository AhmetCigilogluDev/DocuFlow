using DocuFlow.Application.DTO;
using DocuFlow.Application.Interfaces;

namespace DocuFlow.Application.Services
{
    public class DocumentService : IDocumentService
    {

        public Task<IEnumerable<DocumentDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


        public Task<DocumentDto?> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(DocumentDto dto)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(DocumentDto dto)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DocumentDto>> GetByTagAsync(string tag)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<DocumentDto>> GetByUserAsync(string uploadBy)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<DocumentDto>> GetUnapprovedAsync()
        {
            throw new NotImplementedException();
        }

    }

}