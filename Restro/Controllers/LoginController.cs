using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Restro.Models;
using Restro.Services;

namespace Restro.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register/admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Login model)
        {
            try
            {
                var token = await _authService.RegisterAdmin(model);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register/user")]
        public async Task<IActionResult> RegisterUser([FromBody] Login model)
        {
            try
            {
                var token = await _authService.RegisterUser(model);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login/admin")]
        public async Task<IActionResult> AdminLogin([FromBody] Login model)
        {
            try
            {
                var token = await _authService.AdminLogin(model);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login/user")]
        public async Task<IActionResult> UserLogin([FromBody] Login model)
        {
            try
            {
                var token = await _authService.UserLogin(model);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}