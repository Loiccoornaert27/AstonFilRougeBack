using System.ComponentModel.DataAnnotations;

namespace AstonFilRouge_API.Models
{
    public class OpeningDay
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Day;
        [Required]
        public DateTime OpeningHour { get; set; }
        [Required]
        public DateTime ClosingHour { get; set; }
    }
}
