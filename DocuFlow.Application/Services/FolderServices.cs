
using DocuFlow.Application.DTO;
using DocuFlow.Application.Interfaces;
using Microsoft.AspNetCore.Http;
namespace DocuFlow.Application.Services
{

    public class FolderServices : IFolderService
    {

        // public Task<IEnumerable<FolderDto>> GetAllAsync()
        // {
        //     throw new NotImplementedException();
        // }

        public Task<IEnumerable<FolderDto>> GetAllAsync()
{
    var dummyList = new List<FolderDto>
    {
        new FolderDto { Id = Guid.NewGuid(), Name = "Test Folder 1" },
        new FolderDto { Id = Guid.NewGuid(), Name = "Test Folder 2" }
    };

    return Task.FromResult<IEnumerable<FolderDto>>(dummyList);
}

        public Task<FolderDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task AddAsync(FolderDto dto)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(FolderDto dto)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        
public async Task UploadFileAsync(IFormFile file)
{
    var filePath = Path.Combine("Uploads", file.FileName);

    // Klasörü oluştur (yoksa)
    Directory.CreateDirectory("Uploads");

    using var stream = new FileStream(filePath, FileMode.Create);
    await file.CopyToAsync(stream);
}



    }
}