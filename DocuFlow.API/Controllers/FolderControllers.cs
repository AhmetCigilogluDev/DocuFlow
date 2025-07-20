using DocuFlow.Application.DTO;

using DocuFlow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.WebUtilities;
using DocuFlow.Infrastructure.Services;

using Microsoft.AspNetCore.Http;
namespace DocuFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var folders = await _folderService.GetAllAsync();
            return Ok(folders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var folder = await _folderService.GetByIdAsync(id);
            if (folder == null)
                return NotFound();
            return Ok(folder);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FolderDto dto)
        {
            await _folderService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        //   return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto!);


        [HttpPost("upload")]
[Consumes("multipart/form-data")]
public async Task<IActionResult> Upload(IFormFile file)
{
    if (file == null || file.Length == 0)
        return BadRequest("Dosya seçilmedi.");

    await _folderService.UploadFileAsync(file); // Serviste zaten bu metot vardı
    return Ok("Dosya başarıyla yüklendi.");
}




        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _folderService.DeleteAsync(id);
            return NoContent();
        }
    }
}