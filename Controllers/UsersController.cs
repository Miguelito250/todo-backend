using Microsoft.AspNetCore.Mvc;
using todo_backend.Models;
using todo_backend.Services.Interfaces;
using todo_backend.Utils.Reponses;

namespace todo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Response response = await _userService.CreateUserAsync(user);

            if (response.Status == false) return BadRequest(response.StatusMessage);

            string accessToken = (string)response.DataResponse!;

            if (string.IsNullOrEmpty(accessToken)) return BadRequest("Error generating token");

            return Ok(accessToken);
        }
    }
}