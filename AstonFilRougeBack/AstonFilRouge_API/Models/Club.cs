using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstonFilRouge_API.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Capacity { get; set; }
        public int Inside { get; set; }
        public List<OpeningDay> OpeningWeekDays { get; set; }
        public List<DateTime> ExceptionnalClosure { get; set; }
        public List<Course> Planning { get; set; }

    }
}
