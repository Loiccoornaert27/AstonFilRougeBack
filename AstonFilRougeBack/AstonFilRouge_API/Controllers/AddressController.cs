using AstonFilRouge_API.Datas;
using AstonFilRouge_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IRepository<Address> _addressRepo;

        public AddressController(IRepository<Address> addressRepo)
        {
            _addressRepo = addressRepo;
        }

        [HttpGet("/addressList")]
        public IActionResult GetAllAddress()
        {
            return Ok(new
            {
                AddressList = _addressRepo.GetAll()
            });
        }

        [HttpGet("/addressList/{id}")]
        public IActionResult GetAddressById(int id)
        {
            Address found = _addressRepo.GetById(id);
            if (found == null)
            {
                return NotFound(new
                {
                    Message = "Aucune adresse avec cet id trouvée."
                });
            }
            return Ok(new
            {
                Message = "Adresse trouvée",
                Address = found
            });
        }

        [HttpPost("/address")]
        public IActionResult CreateNewAddress([FromBody] Address newAddress)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_addressRepo.Add(newAddress) != null)
            {
                return Ok(new
                {
                    Mesage = "Nouvelle addresse ajoutée avec succès."
                });
            }
            else
            {
                ModelState.AddModelError("Add Address", "Oops il y a eu un problème lors de l'ajout de l'adresse");
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("addressList/{id}")]
        public IActionResult DeleteAddress( int id)
        {
            Address found = _addressRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucune adresse avec cet id trouvée."
            });
            if (_addressRepo.Delete(id)) return Ok(new
            {
                Message = "Adresse supprimée avec succès"
            });
            else
            {
                return BadRequest(new
                {
                    Message = "Erreur lors de la suppression de l'adresse."
                });
            }
        }

        [HttpPatch("/addressList/{id}")]
        public IActionResult EditAddress(int id,[FromBody] Address editedAddress)
        {
            var found = _addressRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucune adresse avec cet id trouvée."
            });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(_addressRepo.Update(id, editedAddress) != null)
            {
                return Ok(new
                {
                    Message = "Adresse modifiée avec succès.",
                    Address = _addressRepo.GetById(id)
                });
            }
            else
            {
                ModelState.AddModelError("Editing Address", "Oops. Il y a eu un problème lors de la modification de l'adresse");
                return BadRequest(ModelState);
            }
        }
    }
}
