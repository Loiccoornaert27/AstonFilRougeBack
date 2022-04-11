using AstonFilRouge_API.Models;
using AstonFilRouge_API.Datas;

namespace AstonFilRouge_API.Controllers.Services
{
    public class ReportingService
    {
        private IRepository<Reservation> _resaRepo;
        private IRepository<Subscription> _subRepo;
        private IRepository<Club> _clubRepo;

        public int GetMonthlyRevenues(int id)
        {
            Club club = _clubRepo.GetById(id);
            int revenues = 0;
            IEnumerable<Subscription> subList = _subRepo.GetAll();
            foreach(Subscription sub in subList )
            {
                if(sub.ClubId == id)
                {
                    if (sub.BillingPeriod == 0)
                    {
                        revenues += sub.Price;
                    }
                    else if(sub.BillingPeriod == 1)
                    {
                        revenues += sub.Price / 12;
                    }
                }
            }
            return revenues;
        }
    }
}
