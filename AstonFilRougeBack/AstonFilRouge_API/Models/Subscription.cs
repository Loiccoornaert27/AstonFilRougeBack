using System.ComponentModel.DataAnnotations;
using static AstonFilRouge_API.Enums.Enumerables;

namespace AstonFilRouge_API.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int ClubId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public BillingPeriod BillingPeriod { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndCommitmentDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
