using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Auth;
using AS.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AS.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IConfiguration _configuration;
        public AuthController(IUserService service, IConfiguration configuration)
        {
            this._service = service;
            this._configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            User? user = await this._service.Login(model.Username, model.Password);

            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("Rating",user.Rating.ToString()),
                    new Claim("IsPremium",user.IsPremium.ToString()),
                });

                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.CreateJwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    subject: claimsIdentity,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                var tokenString = tokenHandler.WriteToken(jwtToken);

                return Ok(tokenString);
            }

            return BadRequest();
        }
    }
}
