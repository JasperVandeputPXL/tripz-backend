using Microsoft.AspNetCore.Mvc;
using Tripz.AppLogic;
using Tripz.Infrastructure;

    namespace Tripz.Api.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly AuthService _authService;

            public AuthController(AuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginRequest request)
            {
                try
                {
                    var user = _authService.Login(request.Username, request.Password);
                    if (user == null)
                        return Unauthorized("Invalid credentials.");
                    return Ok(user);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        public class LoginRequest
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
