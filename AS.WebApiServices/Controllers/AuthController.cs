using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Auth;
using AS.ApplicationServices.ResponseModels.Auth;
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
        private readonly IAuthService _service;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthService service, IConfiguration configuration)
        {
            this._service = service;
            this._configuration = configuration;
        }

        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            try
            {
                AuthResponseModel user = await this._service.Login(model);

                return Ok(GenerateToken(user));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            try
            {
                AuthResponseModel user = await this._service.Register(model);

                return Ok(GenerateToken(user));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GenerateToken(AuthResponseModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> {
                new Claim("UserId", user.Id.ToString()),
                new Claim("Rating",user.Rating.ToString()),
                new Claim("IsPremium", user.IsPremium.ToString())
            };

            if (user.IsAdmin)
                claims.Add(new Claim("IsAdmin", user.IsAdmin.ToString()));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.CreateJwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                subject: claimsIdentity,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return tokenHandler.WriteToken(jwtToken);
        }
    }
}
