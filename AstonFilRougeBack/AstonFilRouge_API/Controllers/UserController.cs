using AstonFilRouge_API.Models;
using AstonFilRouge_API.Datas;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepo;

        public UserController(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("/userList")]
        public IActionResult GetAllUsers()
        {
            return Ok(new
            {
                UserList = _userRepo.GetAll()
            });
        }

        [HttpGet("/userList/{id}")]
        public IActionResult GetUserById(int id)
        {
            User found = _userRepo.GetById(id);
            if(found == null)
            {
                return NotFound(new
                {
                    Message="Pas d'utilisateur avec cet ID."
                });
            }
            return Ok(new
            {
                Message = "User found",
                User = found
            });
        }
    }
}
