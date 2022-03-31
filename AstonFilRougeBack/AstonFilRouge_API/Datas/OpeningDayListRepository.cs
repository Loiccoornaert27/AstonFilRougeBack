using AstonFilRouge_API.Models;

namespace AstonFilRouge_API.Datas
{
    public class OpeningDayListRepository : BaseRepository, IRepository<OpeningDay>
    {
        public OpeningDayListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public OpeningDay Add(OpeningDay entity)
        {
            _context.OpeningDayList.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            _context.OpeningDayList.Remove(GetById(id));
            if (_context.SaveChanges() > 0) return true;
            return false;
        }

        public IEnumerable<OpeningDay> GetAll()
        {
            return _context.OpeningDayList;
        }

        public OpeningDay GetById(int id)
        {
            return _context.OpeningDayList.FirstOrDefault(x => x.Id == id);
        }

        public OpeningDay Update(int id,OpeningDay entity)
        {
            OpeningDay found = GetById(id);
            if (found != null)
            {
                found.Day = entity.Day;
                found.OpeningHour = entity.OpeningHour;
                found.ClosingHour = entity.ClosingHour;

                _context.OpeningDayList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }
    }
}
