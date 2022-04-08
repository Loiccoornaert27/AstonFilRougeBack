using AstonFilRouge_API.Models;

namespace AstonFilRouge_API.Datas
{
    public class CourseListRepository : BaseRepository, IRepository<Course>
    {
        public CourseListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Course Add(Course entity)
        {
            _context.CourseList.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            _context.CourseList.Remove(GetById(id));
            if (_context.SaveChanges() > 0) return true;
            return false;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.CourseList;
        }

        public Course GetById(int id)
        {
            return _context.CourseList.FirstOrDefault(x => x.Id == id);
        }

        public Course Update(int id,Course entity)
        {
            Course found = GetById(id);
            if (found != null)
            {
                found.Title = entity.Title;
                found.Description = entity.Description;
                found.Type = entity.Type;
                found.ClubId = entity.ClubId;
                found.CoachId = entity.CoachId;
                found.Date=entity.Date;
                found.EndHour = entity.EndHour;
                found.Status = entity.Status;
                

                _context.CourseList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(found.Id);
            return null;
        }
    }
}
