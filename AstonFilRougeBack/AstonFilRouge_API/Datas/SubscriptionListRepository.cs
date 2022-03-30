using AstonFilRouge_API.Models;

namespace AstonFilRouge_API.Datas
{
    public class SubscriptionListRepository : BaseRepository, IRepository<Subscription>
    {
        public SubscriptionListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Subscription Add(Subscription entity)
        {
            _context.SubscriptionList.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            _context.SubscriptionList.Remove(GetById(id));
            if (_context.SaveChanges() > 0) return true;
            return false;
        }

        public IEnumerable<Subscription> GetAll()
        {
            return _context.SubscriptionList;
        }

        public Subscription GetById(int id)
        {
            return _context.SubscriptionList.FirstOrDefault(x => x.Id == id);
        }

        public Subscription Update(Subscription entity)
        {
            Subscription found = GetById(entity.Id);
            if (found != null)
            {
                found.ClientId = entity.ClientId;
                found.ClubId = entity.ClubId;
                found.Price = entity.Price;
                found.BillingPeriod = entity.BillingPeriod;
                found.EndCommitmentDate = entity.EndCommitmentDate;
                found.EndDate = entity.EndDate;

                _context.SubscriptionList.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }
    }
}
