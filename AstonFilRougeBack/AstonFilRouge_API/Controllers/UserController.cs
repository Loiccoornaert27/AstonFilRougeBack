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
            if (found == null)
            {
                return NotFound(new
                {
                    Message = "Pas d'utilisateur avec cet ID."
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

        [HttpPatch("/userList/{id}")]
        public IActionResult EditUser(int id, [FromForm] User editedUser)
        {
            var found = _userRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucun utilisateur avec cet id trouvée."
            });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_userRepo.Update(id, editedUser) != null)
            {
                return Ok(new
                {
                    Message = "Utilisateur modifié avec succès.",
                    User = _userRepo.GetById(id)
                });
            }
            else
            {
                ModelState.AddModelError("Editing User", "Oops. Il y a eu un problème lors de la modification de l'utilisateur");
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/userList/{id}")]
        public IActionResult ChangeUserRole([FromForm] int id, User newRole)
        {
            var found = _userRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucun utilisateur avec cet id trouvée."
            });
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(_userRepo.UpdateRole(id, newRole)!= null)
            {
                return Ok(new
                {
                    Message = "Role modifié avec succès",
                    User = _userRepo.GetById(id)
                });
            }
            else
            {
                ModelState.AddModelError("Editing Role", "Oops. Il y a eu un problème lors de la modification de l'utilisateur");
                return BadRequest(ModelState);
            }
        }
    }
}