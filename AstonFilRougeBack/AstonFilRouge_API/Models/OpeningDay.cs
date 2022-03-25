using System.ComponentModel.DataAnnotations;

namespace AstonFilRouge_API.Models
{
    public class OpeningDay
    {
        [Key]
        public int Id { get; set; }
        public DateTime Day;
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
    }
}
