using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstonFilRouge_API.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int Capacity { get; set; }
        public int Inside { get; set; }
        [Required]
        public List<OpeningDay> OpeningWeekDays { get; set; }
        [NotMapped]
        public IEnumerable<DateTime> ExceptionnalClosure { get; set; }
        public List<Course> Planning { get; set; }

    }
}
