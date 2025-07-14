using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyFirstWebApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        //[HttpGet("token")]
        //public IActionResult GetToken()
        //{
        //    var token = GenerateJSONWebToken(101, "Admin"); // ID: 101, Role: Admin
        //    return Ok(new { token });
        //}
        [HttpGet("token")]
        public IActionResult GetToken()
        {
            try
            {
                var token = GenerateJSONWebToken(101, "Admin");
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error occurred: {ex.Message}");
            }
        }


        private string GenerateJSONWebToken(int userId, string userRole)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecretmysuperdupersecret!"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(2), // ⏱ change to 10 later
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
