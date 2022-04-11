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
                    if (sub.BillingPeriod.ToString() == "Monthly")
                    {
                        revenues += sub.Price;
                    }
                    else if (sub.BillingPeriod.ToString() == "Annually")
                    {
                        revenues += sub.Price / 12;
                    }
                }
            }
            return revenues;
        }

        public void UpdatePeopleInside(DateTime time)
        {
            IEnumerable<Reservation> resaList = _resaRepo.GetAll();
            foreach(Reservation resa in resaList)
            {
                if(resa.Course.StartHour == time)
                {
                    Club club = _clubRepo.GetById(resa.Course.ClubId);
                    club.Inside++;
                }
                if(resa.Course.EndHour == time)
                {
                    Club club = _clubRepo.GetById(resa.Course.ClubId);
                    club.Inside--;
                }
            }
        }

        public bool WarningClubAlmostFull(int id)
        {
            Club club = _clubRepo.GetById(id);
            if (club.Inside >= club.Capacity - club.Capacity / 10)
            {
                return false;
            }
            else return true;
        }

        public bool ClubFull(int id)
        {
            Club club = _clubRepo.GetById(id);
            if (club.Inside == club.Capacity) return true;
            else return false;
        }
    }
}
