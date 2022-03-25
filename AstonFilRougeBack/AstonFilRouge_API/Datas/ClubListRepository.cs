using AstonFilRouge_API.Models;

namespace AstonFilRouge_API.Datas
{
    public class ClubListRepository : BaseRepository, IRepository<Club>
    {
        public ClubListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Club Add(Club entity)
        {
            _context.ClubList.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            _context.ClubList.Remove(GetById(id));
            if (_context.SaveChanges() > 0) return true;
            return false;
        }

        public IEnumerable<Club> GetAll()
        {
            return _context.ClubList;
        }

        public Club GetById(int id)
        {
            return _context.ClubList.FirstOrDefault(x => x.Id == id);
        }

        public Club Update(Club entity)
        {
            Club found = GetById(entity.Id);
            if (found != null)
            {
                found.Name = entity.Name;

                _context.ClubList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }
    }
}
