
using DocuFlow.Application.DTO;
using DocuFlow.Application.Interfaces;
namespace DocuFlow.Application.Services
{

    public class FolderServices : IFolderService
    {

       public Task<IEnumerable<FolderDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
       public Task<FolderDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task AddAsync(FolderDto dto)
        {
            throw new NotImplementedException();
        }
       public  Task UpdateAsync(FolderDto dto)
        {
            throw new NotImplementedException();
        }
       public  Task DeleteAsync(Guid id)
                {
            throw new NotImplementedException();
        }
    }
}