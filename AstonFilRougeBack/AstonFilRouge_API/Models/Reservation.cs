using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AstonFilRouge_API.Enums.Enumerables;

namespace AstonFilRouge_API.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey("ClientId")]
        public virtual User? User { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        [Required]
        public ReservationStatus Status { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
    }
}
