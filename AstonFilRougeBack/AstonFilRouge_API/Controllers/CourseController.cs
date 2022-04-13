using AstonFilRouge_API.Datas;
using AstonFilRouge_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AstonFilRouge_API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<Course> _courseRepo;

        public CourseController(IRepository<Course> courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Coach")]
        public IActionResult CreateNewCourse([FromForm] Course newCourse)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var added = _courseRepo.Add(newCourse);
            if (added != null)
            {
                return Ok(new
                {
                    Message = "Nouvelle séance ajoutée avec succès.",
                    CourseId = added.Id
                });
            }
            else
            {
                ModelState.AddModelError("Add Course", "Oops il y a eu un problème lors de l'ajout de la séance");
                return BadRequest(ModelState);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAllCourses()
        {
            return Ok(new
            {
                CourseList = _courseRepo.GetAll()
            });
        }

        [HttpGet("getallbydate/{date}")]
        public IActionResult GetAllCoursesByDate()
        {
            DateTime date = DateTime.Now;
            IEnumerable<Course> found = _courseRepo.GetAllByDate(date);
            if(found == null)
            {
                return NotFound(new
                {
                    Message = "Pas de séance disponible à ce jour"
                });
            }
            return Ok(new
            {
                CourseList = found
            });
        }

        [HttpGet("get/{id}")]
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

        [HttpPatch("update/{id}")]
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

        [HttpDelete("delete/{id}")]
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
    }
}
