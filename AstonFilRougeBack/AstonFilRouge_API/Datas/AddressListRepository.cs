﻿using AstonFilRouge_API.Models;

namespace AstonFilRouge_API.Datas
{
    public class AddressListRepository : BaseRepository, IRepository<Address>
    {
        public AddressListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Address Add(Address entity)
        {
            _context.AddressList.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            _context.AddressList.Remove(GetById(id));
            if (_context.SaveChanges() > 0) return true;
            return false;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.AddressList;
        }

        public Address GetById(int id)
        {
            return _context.AddressList.FirstOrDefault(x => x.Id == id);
        }

        public Address Update(Address entity)
        {
            Address found = GetById(entity.Id);
            if (found != null)
            {
                found.Street = entity.Street;

                _context.AddressList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }
    }
}
