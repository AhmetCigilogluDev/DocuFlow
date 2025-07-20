using DocuFlow.Application.DTO;
using DocuFlow.Application.Interfaces;
using DocuFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using DocuFlow.Domain.Entities;

namespace DocuFlow.Infrastructure.Services
{

    public class DocumentService : IDocumentService
    {

        
    private readonly AppDbContext _context;

    public DocumentService(AppDbContext context)
    {
        _context = context;
    }

        // public Task<IEnumerable<DocumentDto>> GetAllAsync()
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<IEnumerable<DocumentDto>> GetAllAsync()
        {
            var documents = await _context.Documents.ToListAsync();

            return documents.Select(doc => new DocumentDto
            {
                Id = doc.Id,
                Name = doc.Name,
                Path = doc.Path,
                UploadedBy = doc.UploadedBy
                // varsa diğer alanlar
            }).ToList();
        }



        public Task<DocumentDto?> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        // public Task AddAsync(DocumentDto dto)
        // {
        //     throw new NotImplementedException();
        // }
        public async Task AddAsync(DocumentDto dto)
{
    var document = new Document
    {
        Id = Guid.NewGuid(),
        Name = dto.Name,
        Path = dto.Path,
        Title = dto.Title,
        FileType = dto.FileType,
        UploadedBy = dto.UploadedBy,
        CreatedAt = DateTime.Now,
        LastModifiedAt = DateTime.Now,
        IsApproved = dto.IsApproved,
        Tags = dto.Tags ?? new List<string>(),
        FolderId = null, // İstersen DTO'dan alırsın
        VersionNumber = 1
    };

    _context.Documents.Add(document);
    await _context.SaveChangesAsync();
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