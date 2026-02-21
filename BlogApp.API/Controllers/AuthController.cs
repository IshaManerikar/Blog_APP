using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
        [ApiController]
        [Route("api/auth")]
        public class AuthController : ControllerBase
        {
            private readonly AuthService _service;

            public AuthController(AuthService service)
            {
                _service = service;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterDto dto)
            {
                await _service.RegisterAsync(dto);
                return Ok("User registered successfully");
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginDto dto)
            {
                var result = await _service.LoginAsync(dto);
                return Ok(result);
            }
    }
}
