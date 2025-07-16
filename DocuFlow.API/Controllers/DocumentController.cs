using Microsoft.AspNetCore.Http;
using DocuFlow.Application.Interfaces;
using DocuFlow.Application.DTO;
using Microsoft.AspNetCore.Mvc;


namespace DocuFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _documentService.GetAllAsync();
            return Ok(documents);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null)
                return NotFound();


            return Ok(document);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DocumentDto dto)
        {
            await _documentService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DocumentDto dto)
        {
            await _documentService.UpdateAsync(dto);
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _documentService.DeleteAsync(id);
            return NoContent();
        }
    }

}
