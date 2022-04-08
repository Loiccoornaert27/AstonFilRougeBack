using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AstonFilRouge_API.Enums.Enumerables;

namespace AstonFilRouge_API.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public CourseType Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime StartHour { get; set; }
        [Required]
        public DateTime EndHour { get; set; }
        [Required]
        public CourseStatus Status { get; set; }
        [Required]
        public int ClubId { get; set; }
        [ForeignKey("ClubId")]
        public virtual Club? Club { get; set; }
        [Required]
        public int CoachId { get; set; }
        [ForeignKey("CoachId")]
        public virtual User? User { get; set; }
        [Required]
        public int Limit { get; set; }
        [Required]
        public string Title { get; set; } 
        [Required]
        public string Description { get; set; }
    }
}
