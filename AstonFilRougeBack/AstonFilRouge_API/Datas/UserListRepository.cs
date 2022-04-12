using AstonFilRouge_API.Controllers.Services;
using AstonFilRouge_API.Models;

namespace AstonFilRouge_API.Datas
{
    public class UserListRepository : BaseRepository, IRepository<User>
    {
        private UploadService _uploadPic;
        public UserListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User Add(User entity, IFormFile? picture)
        {
            if(picture== null)
            {
                entity.AvatarUrl = "default";
            }
            else
            {
                entity.AvatarUrl = _uploadPic.UploadPicture(picture, "UsersAvatarList");
            }
            
            _context.UserList.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public User Add(User entity)
        {
            entity.AvatarUrl = "default";   
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

        public User GetByEmail(string email)
        {
            return _context.UserList.FirstOrDefault(x => x.Email == email);
        }

        public User GetById(int id)
        {
            return _context.UserList.FirstOrDefault(x => x.Id == id);
        }

        public User Update(int id,User entity, IFormFile? picture)
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
                found.Role = entity.Role;
                if(picture != null)
                {
                    found.AvatarUrl = _uploadPic.UploadPicture(picture, "UsersAvatarList");
                }
                

                _context.UserList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(found.Id);
            return null;
        }

        public User Update(int id, User entity)
        {
            throw new NotImplementedException();
        }

        //public User UpdateRole(int id, User entity)
        //{
        //    var found = GetById(id);
        //    if(found != null)
        //    {
        //        found.Role = entity.Role;
        //        found.UpdateDate= DateTime.Now;

        //        _context.UserList.Update(found);
        //    }
        //    if (_context.SaveChanges() > 0) return GetById(found.Id);
        //    return null;
        //}
    }
}
