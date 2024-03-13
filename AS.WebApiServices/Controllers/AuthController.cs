using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
            bool success = await this._service.Login(model.Username, model.Password);

            if (success)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                  _configuration["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(token);
            }

            return BadRequest();
        }
    }
}
