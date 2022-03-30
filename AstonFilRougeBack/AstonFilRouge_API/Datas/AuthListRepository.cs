using AstonFilRouge_API.Models;

namespace AstonFilRouge_API.Datas
{
    public class AuthListRepository : BaseRepository, IRepository<Auth>
    {
        public AuthListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Auth Add(Auth entity)
        {
            _context.AuthList.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            _context.AuthList.Remove(GetById(id));
            if (_context.SaveChanges() > 0) return true;
            return false;
        }

        public IEnumerable<Auth> GetAll()
        {
            return _context.AuthList;
        }

        public Auth GetById(int id)
        {
            return _context.AuthList.FirstOrDefault(x => x.Id == id);
        }

        public Auth Update(Auth entity)
        {
            Auth found = GetById(entity.Id);
            if (found != null)
            {
                found.Email = entity.Email;
                found.Password = entity.Password;

                _context.AuthList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }
    }
}
