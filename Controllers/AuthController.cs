using Microsoft.AspNetCore.Mvc;
using todo_backend.DTOS;
using todo_backend.Services.Interfaces;
using todo_backend.Utils.Reponses;
namespace todo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAccount([FromBody]LoginRequest credentials)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Response response = await _authService.AuthenticateUserAsync(credentials.Email, credentials.Password);

            if (response.Status == false) return Unauthorized(response.StatusMessage);

            AuthResponse authResponse = (AuthResponse)response.DataResponse!;

            return Ok(authResponse);
        }
    }
}
