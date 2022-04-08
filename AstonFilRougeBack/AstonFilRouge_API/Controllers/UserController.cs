using AstonFilRouge_API.Models;
using AstonFilRouge_API.Datas;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepo;

        public UserController(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("/getall")]
        public IActionResult GetAllUsers()
        {
            return Ok(new
            {
                UserList = _userRepo.GetAll()
            });
        }

        [HttpGet("get")]
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

        [HttpPost("create")]
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

        [HttpPatch("update")]
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

        [HttpPatch("updaterole")]
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

        [HttpDelete("delete")]
        public IActionResult DeleteUser(int id)
        {
            var found = _userRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucun utilisateur avec cet id trouvée."
            });
            if (_userRepo.Delete(id)) return Ok(new
            {
                Message = "Utilisateur supprimé avec succès"
            });
            else
            {
                return BadRequest(new
                {
                    Message = "Erreur lors de la suppression de l'adresse."
                });
            }
        }
    }
}