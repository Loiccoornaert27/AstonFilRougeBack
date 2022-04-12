using AstonFilRouge_API.Datas;
using AstonFilRouge_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/subscription")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IRepository<Subscription> _subRepo;

        public SubscriptionController(IRepository<Subscription> subRepo)
        {
            _subRepo = subRepo;
        }

        [HttpPost("create")]
        public IActionResult CreateNewSubscription([FromForm] Subscription newSub)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_subRepo.Add(newSub) != null)
            {
                return Ok(new
                {
                    Message = "Nouvel abonnement ajouté avec succès.",
                    SubscriptionId = newSub.Id
                });
            }
            else
            {
                ModelState.AddModelError("Add Subscription", "Oops. Il y a eu un problème lors de l'ajout de l'abonnement");
                return BadRequest(ModelState);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAllSubscriptions()
        {
            return Ok(new
            {
                SubscriptionList = _subRepo.GetAll()
            });
        }

        [HttpGet("get/{id}")]
        public IActionResult GetSubscriptionById(int id)
        {
            Subscription found = _subRepo.GetById(id);
            if (found == null)
            {
                return NotFound(new
                {
                    Message = "Aucun abonnement avec cet id trouvée."
                });
            }
            return Ok(new
            {
                Message = "Abonnement trouvé",
                Address = found
            });
        }

        [HttpPatch("update/{id}")]
        public IActionResult EditSubscription(int id, [FromForm] Subscription editedSub)
        {
            var found = _subRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucun abonnement avec cet id trouvée."
            });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_subRepo.Update(id, editedSub) != null)
            {
                return Ok(new
                {
                    Message = "Abonnement modifié avec succès.",
                    Subscription = _subRepo.GetById(id)
                });
            }
            else
            {
                ModelState.AddModelError("Editing Subscription", "Oops. Il y a eu un problème lors de la modification de l'abonnement");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSubscription(int id)
        {
            Subscription found = _subRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucun abonnement avec cet id trouvé."
            });
            if (_subRepo.Delete(id)) return Ok(new
            {
                Message = "Abonnement supprimé avec succès"
            });
            else
            {
                return BadRequest(new
                {
                    Message = "Erreur lors de la suppression de l'abonnement."
                });
            }
        }
    }
}
