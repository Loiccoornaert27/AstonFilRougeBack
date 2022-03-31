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

        [HttpPost("/user")]
        public IActionResult CreateNewUser([FromForm] User newUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_userRepo.Add(newUser) != null)
            {
                return Ok(new
                {
                    Message = "New user added with success"
                });
            }
            else
            {
                ModelState.AddModelError("Add User", "Something went wrong when adding the user to the database");
                return BadRequest(ModelState);
            }
        }

    }
}
