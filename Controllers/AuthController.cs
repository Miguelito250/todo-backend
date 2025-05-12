using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using todo_backend.DTOS;
using todo_backend.Services.Interfaces;
using todo_backend.Utils.Reponses;
namespace todo_backend.Controllers
{
    /// <summary>
    /// El controlador AuthController maneja la autenticacion de los usuarios
    /// y sus respectivas respuestas a las diferentes peticiones
    /// hay una funcion que valida el token y otra que maneja el login de usuarios

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult ValidateToken() 
        {
            return NoContent();
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
