using DocuFlow.Application.DTO;
using DocuFlow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocuFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var token = await _userService.RegisterAsync(dto);
            if (token == null)
                return BadRequest("Email already exists.");

            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _userService.LoginAsync(dto);
            if (token == null)
                return Unauthorized("Invalid credentials.");

            return Ok(new { token });
        }
    }
}
 