using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AstonFilRouge_API.Enums.Enumerables;

namespace AstonFilRouge_API.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
