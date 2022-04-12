﻿using AstonFilRouge_API.Datas;
using AstonFilRouge_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/club")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IRepository<Club> _clubRepo;

        public ClubController(IRepository<Club> clubRepo)
        {
            _clubRepo = clubRepo;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateNewClub([FromForm] Club newClub)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var added = _clubRepo.Add(newClub)
            if (added != null)
            {
                return Ok(new
                {
                    Message = "Nouveau club ajouté avec succès.",
                    ClubId = added.Id
                });
            }
            else
            {
                ModelState.AddModelError("Add Club", "Oops il y a eu un problème lors de l'ajout du club");
                return BadRequest(ModelState);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAllClubs()
        {
            return Ok(new
            {
                ClubList = _clubRepo.GetAll()
            });
        }

        [HttpGet("get/{id}")]
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

        [HttpPatch("update/{id}")]
        [Authorize(Roles = "Manager")]
        public IActionResult EditClub(int id, [FromForm] Club editedClub)
        {
            var found = _clubRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucun club avec cet id trouvé."
            });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_clubRepo.Update(id, editedClub) != null)
            {
                return Ok(new
                {
                    Message = "Club modifié avec succès.",
                    Club = _clubRepo.GetById(id)
                });
            }
            else
            {
                ModelState.AddModelError("Editing Club", "Oops. Il y a eu un problème lors de la modification du club");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("delete/{id}")]
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
    }
}
