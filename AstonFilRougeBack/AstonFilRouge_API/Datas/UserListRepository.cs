﻿using AstonFilRouge_API.Models;

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

        public User Update(User entity)
        {
            User found = GetById(entity.Id);
            if (found != null)
            {
                found.FirstName = entity.FirstName;
                found.LastName = entity.LastName;
                found.Email = entity.Email;
                found.Club = entity.Club;
                found.UpdateDate = DateTime.Now ;
                found.Role= entity.Role;
                found.PhoneNumber = entity.PhoneNumber;
                found.Description = entity.Description;
                found.Address = entity.Address;
                

                _context.UserList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }
    }
}
