using System.ComponentModel.DataAnnotations;
using static AstonFilRouge_API.Enums.Enumerables;

namespace AstonFilRouge_API.Models
{
    public class OpeningDay
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Day Day;
        [Required]
        public DateTime OpeningHour { get; set; }
        [Required]
        public DateTime ClosingHour { get; set; }
    }
}
