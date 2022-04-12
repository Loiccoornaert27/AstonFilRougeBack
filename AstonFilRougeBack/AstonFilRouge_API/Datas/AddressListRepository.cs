using AstonFilRouge_API.Models;

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

        public Address Add(Address entity, IFormFile? picture)
        {
            throw new NotImplementedException();
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

        public Address GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Address GetById(int id)
        {
            return _context.AddressList.FirstOrDefault(x => x.Id == id);
        }

        public Address Update(int id, Address entity)
        {
            Address found = GetById(id);
            if (found != null)
            {
                found.Num= entity.Num;
                found.Street = entity.Street;
                found.Complement = entity.Complement;
                found.ZipCode = entity.ZipCode;
                found.City = entity.City;

                _context.AddressList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(found.Id);
            return null;
        }

        public Address Update(int id, Address entity, IFormFile? picture)
        {
            throw new NotImplementedException();
        }
    }
}
