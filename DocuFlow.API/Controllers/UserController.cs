using DocuFlow.Application.DTO;
using DocuFlow.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocuFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Tüm endpoint'ler JWT ile korunur
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserDto dto)
        {
            var result = await _userService.UpdateAsync(id, dto);
            return result ? NoContent() : NotFound();
        }
    }
}
