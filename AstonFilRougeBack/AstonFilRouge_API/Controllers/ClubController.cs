using AstonFilRouge_API.Datas;
using AstonFilRouge_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IRepository<Club> _clubRepo;

        public ClubController(IRepository<Club> clubRepo)
        {
            _clubRepo = clubRepo;
        }

        [HttpGet("/clubList")]
        public IActionResult GetAllClubs()
        {
            return Ok(new
            {
                ClubList = _clubRepo.GetAll()
            });
        }

        [HttpGet("/clubList/{id}")]
        public IActionResult GetClubById(int id)
        {
            Club found = _clubRepo.GetById(id);
            if (found == null)
            {
                return NotFound(new
                {
                    Message = "Aucun club avec cet id trouvé."
                });
            }
            return Ok(new
            {
                Message = "Club trouvé",
                Club = found
            });
        }

        [HttpPost("/clubList")]
        [Authorize(Roles="Admin")]
        public IActionResult CreateNewClub([FromBody] Club newClub)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_clubRepo.Add(newClub) != null)
            {
                return Ok(new
                {
                    Mesage = "Nouveau club ajouté avec succès."
                });
            }
            else
            {
                ModelState.AddModelError("Add Club", "Oops il y a eu un problème lors de l'ajout du club");
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("clubList/{id}")]
        public IActionResult DeleteClub(int id)
        {
            Club found = _clubRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucun club avec cet id trouvée."
            });
            if (_clubRepo.Delete(id)) return Ok(new
            {
                Message = "Club supprimé avec succès"
            });
            else
            {
                return BadRequest(new
                {
                    Message = "Erreur lors de la suppression du club."
                });
            }
        }
        //Elle pose problème faudra la fix
        //[HttpPatch("/clubList/{id}")]
        //[Authorize(Roles = "Admin")]
        //public IActionResult EditClub(int id, [FromBody] Club editedClub)
        //{
        //    var found = _clubRepo.GetById(id);
        //    if (found == null) return NotFound(new
        //    {
        //        Message = "Aucun club avec cet id trouvé."
        //    });

        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    if (_clubRepo.Update(id, editedClub) != null)
        //    {
        //        return Ok(new
        //        {
        //            Message = "Club modifié avec succès.",
        //            Club = _clubRepo.GetById(id)
        //        });
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("Editing Club", "Oops. Il y a eu un problème lors de la modification du club");
        //        return BadRequest(ModelState);
        //    }
        }
    }
}
