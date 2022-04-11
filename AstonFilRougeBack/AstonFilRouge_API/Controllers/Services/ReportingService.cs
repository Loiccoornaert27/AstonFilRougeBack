using AstonFilRouge_API.Models;
using AstonFilRouge_API.Datas;

namespace AstonFilRouge_API.Controllers.Services
{
    public class ReportingService
    {
        private IRepository<Reservation> _resaRepo;
        private IRepository<Subscription> _subRepo;
        private IRepository<Club> _clubRepo;
        private IRepository<Course> _courseRepo;

        //Fonction qui calcule le chiffre d'affaire d'une salle par mois
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


        //Fonction qui va modifier le contenu de inside dans les différents clubs en fonction du temps
        public void UpdatePeopleInside(DateTime time)
        {
            IEnumerable<Reservation> resaList = _resaRepo.GetAll();
            foreach(Reservation resa in resaList)
            {
                Club club = _clubRepo.GetById(resa.Course.ClubId);
                if (resa.Course.StartHour == time && !ClubFull(club.Id, time))
                {   
                    club.Inside++;
                }
                if(resa.Course.EndHour == time)
                {
                    club.Inside--;
                }
            }
        }

        //Fonction qui va calculer le nombre de gens dans une salle en fonction des reservations
        public int GetInsidePerHour(int id,DateTime time)
        {
            IEnumerable<Reservation> resaList = _resaRepo.GetAll();
            Club club = _clubRepo.GetById(id);
            int sum = 0;
            foreach (Reservation resa in resaList)
            {
                if(resa.Course.ClubId == club.Id)
                {
                    if(resa.Course.StartHour <= time && resa.Course.EndHour >= time) sum++;
                }
            }
            return sum;
        }

        //public bool WarningClubAlmostFull(int id)
        //{
        //    Club club = _clubRepo.GetById(id);
        //    if (club.Inside >= club.Capacity - club.Capacity / 10)
        //    {
        //        return false;
        //    }
        //    else return true;
        //}


        //Fonction qui calcule si un club est plein à une heure donnée
        public bool ClubFull(int id, DateTime time)
        {
            Club club = _clubRepo.GetById(id);
            if (GetInsidePerHour(id, time) == club.Capacity) return true;
            else return false;
        }

        public int GetCourseAttendance(int id)
        {
            Course course = _courseRepo.GetById(id);
            IEnumerable<Reservation> resaList = _resaRepo.GetAll();
            int attendance = 0;
            foreach(Reservation resa in resaList)
            {
                if(resa.CourseId == course.Id) attendance++;
            }
            return attendance;
        }


        public bool CourseFull(int id)
        {
            Course course = _courseRepo.GetById(id);
            if (GetCourseAttendance(id) == course.Limit) return true;
            else return false;
        }
    }
}
