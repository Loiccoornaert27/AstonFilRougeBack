using System;
using System.ComponentModel.DataAnnotations;
using AstonFilRouge_API.Datas;
using AstonFilRouge_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepo;

        public UserController(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("create")]
        public IActionResult CreateNewUser(User newUser/*, IFormFile? picture*/)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            //User added;
            //if (picture == null)
            //{
            //    added = _userRepo.Add(newUser);
            //}
            //else
            //{
            //    added = _userRepo.Add(newUser, picture);
            //}
            User added = _userRepo.Add(newUser);
            if (added != null)
            {
                return Ok(new
                {
                    Message = "New user added with success",
                    UserId = added.Id
                });
            }
            else
            {
                ModelState.AddModelError("Add User", "Something went wrong when adding the user to the database");
                return BadRequest(ModelState);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAllUsers()
        {
            return Ok(new
            {
                UserList = _userRepo.GetAll()
            });
        }

        [HttpGet("getbyid/{id}")]
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

        [HttpGet("getbyemail/{email}")]
        public IActionResult GetUSerByEmail(string email)
        {
            User found = _userRepo.GetByEmail(email);
            if (found == null)
            {
                return NotFound(new
                {
                    Message = "Aucun utilisateur avec cet E-Mail n'a été trouvé"
                });
            }
            return Ok(new
            {
                Message = "User found",
                User = found
            });
        }

        [HttpPatch("update/{id}")]
        public IActionResult EditUser(int id, [FromForm] User editedUser, IFormFile? picture)
        {
            var found = _userRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucun utilisateur avec cet id trouvée."
            });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_userRepo.Update(id, editedUser, picture) != null)
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

        //[HttpPatch("updaterole")]
        //public IActionResult ChangeUserRole([FromForm] int id, User newRole)
        //{
        //    var found = _userRepo.GetById(id);
        //    if (found == null) return NotFound(new
        //    {
        //        Message = "Aucun utilisateur avec cet id trouvée."
        //    });
        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    if (_userRepo.UpdateRole(id, newRole) != null)
        //    {
        //        return Ok(new
        //        {
        //            Message = "Role modifié avec succès",
        //            User = _userRepo.GetById(id)
        //        });
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("Editing Role", "Oops. Il y a eu un problème lors de la modification de l'utilisateur");
        //        return BadRequest(ModelState);
        //    }
        //}

        [HttpDelete("delete/{id}")]
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