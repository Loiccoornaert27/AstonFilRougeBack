using AstonFilRouge_API.Models;

namespace AstonFilRouge_API.Datas
{
    public class ReservationListRepository : BaseRepository, IRepository<Reservation>
    {
        public ReservationListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Reservation Add(Reservation entity)
        {
            _context.ReservationList.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public Reservation Add(Reservation entity, IFormFile? picture)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            _context.ReservationList.Remove(GetById(id));
            if (_context.SaveChanges() > 0) return true;
            return false;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.ReservationList;
        }

        public Reservation GetById(int id)
        {
            return _context.ReservationList.FirstOrDefault(x => x.Id == id);
        }

        public Reservation Update(int id, Reservation entity)
        {
            Reservation found = GetById(id);
            if (found != null)
            {
                found.ClientId = entity.ClientId;
                found.CourseId = entity.CourseId;
                found.Status = entity.Status;
                found.RequestDate = entity.RequestDate;

                _context.ReservationList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(found.Id);
            return null;
        }

        public Reservation Update(int id, Reservation entity, IFormFile? picture)
        {
            throw new NotImplementedException();
        }
    }
}
