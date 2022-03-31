using AstonFilRouge_API.Models;
using AstonFilRouge_API.Datas;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllConnections")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepository<User> _userRepo;
        private readonly IConfiguration _config;

        public AuthController(IRepository<User> UserRepo, IConfiguration config)
        {
            _userRepo = UserRepo;
            _config = config;
        }

        [HttpPost("/authenticate")]
        public IActionResult Authenticate([FromBody] User auth)
        {
            User? found = _userRepo.GetAll().ToList().FirstOrDefault(x => x.Email == auth.Email && x.Password== auth.Password);
            if (found != null)
            {
                var claimList = new List<Claim>()
                {
                new Claim(ClaimTypes.NameIdentifier, auth.Email),
                new Claim(ClaimTypes.Email, auth.Email),
                new Claim(ClaimTypes.Role, auth.Role.ToString())

                };
                var expiresAt = DateTime.UtcNow.AddMinutes(30);

                return Ok(new
                {
                    token = CreateToken(claimList, expiresAt),
                    expiresAt = expiresAt,
                });
            }
            ModelState.AddModelError("Unauthorized", "You are not authorized to access the endpoint");
            return Unauthorized(ModelState);

        }
        private string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
        {
            var secretKey = Encoding.ASCII.GetBytes(_config["JWT:SecretKey"]);

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAt,
                audience: _config["JWT:ValidAudience"],
                issuer: _config["JWT:ValidIssuer"],
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
