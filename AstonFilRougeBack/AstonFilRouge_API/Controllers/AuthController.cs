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
        private readonly IRepository<Auth> _authRepo;
        private readonly IConfiguration _config;

        public AuthController(IRepository<Auth> authRepo, IConfiguration config)
        {
            _authRepo = authRepo;
            _config = config;
        }

        [HttpPost("/authenticate")]
        public IActionResult Authenticate([FromBody] Auth auth)
        {
            Auth? found = _authRepo.GetAll().ToList().FirstOrDefault(x => x.Email == auth.Email && x.Password== auth.Password);
            if (found != null)
            {
                var claimList = new List<Claim>()
                {
                new Claim(ClaimTypes.NameIdentifier, auth.Email),
                new Claim(ClaimTypes.Email, auth.Email)

                };
                var expiresAt = DateTime.UtcNow.AddMinutes(30);

                return Ok(new
                {
                    token = CreateToken(claimList, expiresAt),
                    expiresAt = expiresAt,
                });
            }
        }
    }
}
