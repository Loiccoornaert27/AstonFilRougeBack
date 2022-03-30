using AstonFilRouge_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AstonFilRouge_API.Datas
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<Auth> AuthList { get; set; }
        public DbSet<Address> AddressList { get; set; }
        public DbSet<Club> ClubList { get; set; }
        public DbSet<Course> CourseList { get; set; }
        public DbSet<OpeningDay> OpeningDayList { get; set;}
        public DbSet<Reservation> ReservationList { get; set; }
        public DbSet<Subscription> SubscriptionList { get; set; }
        public DbSet<User> UserList { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
