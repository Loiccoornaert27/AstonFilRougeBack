using static AstonFilRouge_API.Enums.Enumerables;

namespace AstonFilRouge_API.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Course Course { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
