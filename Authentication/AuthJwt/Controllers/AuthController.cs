using AuthJwt.Data;
using AuthJwt.Models;
using AuthJwt.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AuthJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthDbContext _context;

        public AuthController(AuthDbContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserAuth user)
        {
            user.Password = PasswordHasher.HashPassword(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User is Created Successfully");
        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] UserAuth user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Name == user.Name);
            if (existingUser != null)
            {
                var storedPassword = existingUser.Password;

                bool IsPasswordValid = PasswordHasher.VerifyPassword(storedPassword, user.Password);

                if (existingUser == null || !IsPasswordValid)
                {
                    return Unauthorized("Invalid username or password");
                }
                else
                {
                    var tokenMaker = new JwtTokenMaker();
                    var token = tokenMaker.GenerateJwtToken(existingUser.Id.ToString(), existingUser.UserRole);
                    return Ok(new { Token = token });
                }
            }
            else
            {
                return BadRequest("User is not Found");
            }
        }
    }
}
