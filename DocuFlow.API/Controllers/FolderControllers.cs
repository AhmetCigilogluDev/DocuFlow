using DocuFlow.Application.DTO;
using DocuFlow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.WebUtilities;

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
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);   }
        //   return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto!);

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]FolderDto dto)
        {
            await _folderService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _folderService.DeleteAsync(id);
            return NoContent();
        }
    }
}