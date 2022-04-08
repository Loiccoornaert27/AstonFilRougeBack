using AstonFilRouge_API.Models;

namespace AstonFilRouge_API.Datas
{
    public class UserListRepository : BaseRepository, IRepository<User>
    {
        public UserListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User Add(User entity)
        {
            _context.UserList.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            _context.UserList.Remove(GetById(id));
            if (_context.SaveChanges() > 0) return true;
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.UserList;
        }

        public User GetById(int id)
        {
            return _context.UserList.FirstOrDefault(x => x.Id == id);
        }

        public User Update(int id,User entity)
        {
            User found = GetById(id);
            if (found != null)
            {
                found.FirstName = entity.FirstName;
                found.LastName = entity.LastName;
                found.Email = entity.Email;
                found.ClubId = entity.ClubId;
                found.UpdateDate = DateTime.Now;
                found.PhoneNumber = entity.PhoneNumber;
                found.Description = entity.Description;
                found.AddressId = entity.AddressId;
                

                _context.UserList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public User UpdateRole(int id, User entity)
        {
            var found = GetById(id);
            if(found != null)
            {
                found.Role = entity.Role;
                _context.UserList.Update(found);
            }
            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }
    }
}
