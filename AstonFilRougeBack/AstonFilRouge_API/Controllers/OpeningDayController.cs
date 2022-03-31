using AstonFilRouge_API.Datas;
using AstonFilRouge_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningDayController : ControllerBase
    {
        private readonly IRepository<OpeningDay> _odRepo;

        public OpeningDayController(IRepository<OpeningDay> odRepo)
        {
            _odRepo = odRepo;
        }

        [HttpGet("/OpeningDayList")]
        public IActionResult GetAllOpeningDays()
        {
            return Ok(new
            {
                OpeningDayList = _odRepo.GetAll()
            });
        }

        [HttpGet("/openingDayList/{id}")]
        public IActionResult GetOpeningDayById(int id)
        {
            OpeningDay found = _odRepo.GetById(id);
            if (found == null)
            {
                return NotFound(new
                {
                    Message = "Aucune journée d'ouverture avec cet id trouvée."
                });
            }
            return Ok(new
            {
                Message = "Journée d'ouverture trouvée",
                Course = found
            });
        }

        [HttpPost("/openingDayList")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateNewOpeningDay([FromBody] OpeningDay newOD)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_odRepo.Add(newOD) != null)
            {
                return Ok(new
                {
                    Mesage = "Journée d'ouverture ajoutée avec succès."
                });
            }
            else
            {
                ModelState.AddModelError("Add OpeningDay", "Oops il y a eu un problème lors de l'ajout de la journée d'ouverture");
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("openingDayList/{id}")]
        public IActionResult DeleteOpeningDay(int id)
        {
            OpeningDay found = _odRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucune journée d'ouverture avec cet id trouvée."
            });
            if (_odRepo.Delete(id)) return Ok(new
            {
                Message = "Journée d'ouverture supprimée avec succès"
            });
            else
            {
                return BadRequest(new
                {
                    Message = "Erreur lors de la suppression de la journée d'ouverture."
                });
            }
        }

        [HttpPatch("/openingDayList/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditOpeningDay(int id, [FromBody] OpeningDay editedOD)
        {
            var found = _odRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucune journée d'ouverture avec cet id trouvée."
            });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_odRepo.Update(id, editedOD) != null)
            {
                return Ok(new
                {
                    Message = "Séance modifiée avec succès.",
                    OpeningDay = _odRepo.GetById(id)
                });
            }
            else
            {
                ModelState.AddModelError("Editing OpeningDay", "Oops. Il y a eu un problème lors de la modification de la journée d'ouverture");
                return BadRequest(ModelState);
            }
        }
    }
}
