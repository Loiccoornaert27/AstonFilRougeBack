﻿using AstonFilRouge_API.Datas;
using AstonFilRouge_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IRepository<Reservation> _resaRepo;

        public ReservationController(IRepository<Reservation> resaRepo)
        {
            _resaRepo = resaRepo;
        }

        [HttpPost("create")]
        public IActionResult CreateNewReservation([FromForm] Reservation newResa)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_resaRepo.Add(newResa) != null)
            {
                return Ok(new
                {
                    Message = "Nouvelle réservation ajoutée avec succès."
                });
            }
            else
            {
                ModelState.AddModelError("Add Reservation", "Oops il y a eu un problème lors de l'ajout de la réservation.");
                return BadRequest(ModelState);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAllReservations()
        {
            return Ok(new
            {
                ReservationList = _resaRepo.GetAll()
            });
        }

        [HttpGet("get/{id}")]
        public IActionResult GetReservationById(int id)
        {
            Reservation found = _resaRepo.GetById(id);
            if (found == null)
            {
                return NotFound(new
                {
                    Message = "Aucune réservation avec cet id trouvée."
                });
            }
            return Ok(new
            {
                Message = "Réservation trouvée",
                Reservation = found
            });
        }

        [HttpPatch("update/{id}")]
        public IActionResult EditReservation(int id, [FromForm] Reservation editedResa)
        {
            var found = _resaRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucune réservation avec cet id trouvée."
            });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_resaRepo.Update(id, editedResa) != null)
            {
                return Ok(new
                {
                    Message = "Reservation modifiée avec succès.",
                    Reservation = _resaRepo.GetById(id)
                });
            }
            else
            {
                ModelState.AddModelError("Editing Reservation", "Oops. Il y a eu un problème lors de la modification de la réservation");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            Reservation found = _resaRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucune réservation avec cet id trouvée."
            });
            if (_resaRepo.Delete(id)) return Ok(new
            {
                Message = "Réservation supprimée avec succès"
            });
            else
            {
                return BadRequest(new
                {
                    Message = "Erreur lors de la suppression de la réservation."
                });
            }
        }
    }
}
