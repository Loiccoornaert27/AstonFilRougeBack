using AstonFilRouge_API.Datas;
using AstonFilRouge_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<Course> _courseRepo;

        public CourseController(IRepository<Course> courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet("/courseList")]
        public IActionResult GetAllCourses()
        {
            return Ok(new
            {
                CourseList = _courseRepo.GetAll()
            });
        }

        [HttpGet("/courseList/{id}")]
        public IActionResult GetCourseById(int id)
        {
            Course found = _courseRepo.GetById(id);
            if (found == null)
            {
                return NotFound(new
                {
                    Message = "Aucune séance avec cet id trouvée."
                });
            }
            return Ok(new
            {
                Message = "Séance trouvée",
                Course = found
            });
        }

        [HttpPost("/courseList")]
        [Authorize(Roles = "Coach")]
        public IActionResult CreateNewCourse([FromForm] Course newCourse)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_courseRepo.Add(newCourse) != null)
            {
                return Ok(new
                {
                    Message = "Nouvelle séance ajoutée avec succès."
                });
            }
            else
            {
                ModelState.AddModelError("Add Course", "Oops il y a eu un problème lors de l'ajout de la séance");
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("courseList/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            Course found = _courseRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucune séance avec cet id trouvée."
            });
            if (_courseRepo.Delete(id)) return Ok(new
            {
                Message = "Séance supprimée avec succès"
            });
            else
            {
                return BadRequest(new
                {
                    Message = "Erreur lors de la suppression de la séance."
                });
            }
        }

        [HttpPatch("/courseList/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditClub(int id, [FromForm] Course editedCourse)
        {
            var found = _courseRepo.GetById(id);
            if (found == null) return NotFound(new
            {
                Message = "Aucune séance avec cet id trouvée."
            });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_courseRepo.Update(id, editedCourse) != null)
            {
                return Ok(new
                {
                    Message = "Séance modifiée avec succès.",
                    Course = _courseRepo.GetById(id)
                });
            }
            else
            {
                ModelState.AddModelError("Editing Course", "Oops. Il y a eu un problème lors de la modification de la séance");
                return BadRequest(ModelState);
            }
        }
    }
}
