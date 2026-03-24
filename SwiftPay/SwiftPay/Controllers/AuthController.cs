using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Services.Interfaces;

namespace SwiftPay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid registration data.", errors = ModelState });
            }

            try
            {
                var user = await _authService.RegisterAsync(dto);
                return Ok(new { message = "User registered successfully.", data = user });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid login data.", errors = ModelState });
            }

            try
            {
                var result = await _authService.LoginAsync(dto);
                return Ok(new { message = "Login successful.", data = result });
            }
            catch (InvalidOperationException ex)
            {
                // Return specific message from service for better UX
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
