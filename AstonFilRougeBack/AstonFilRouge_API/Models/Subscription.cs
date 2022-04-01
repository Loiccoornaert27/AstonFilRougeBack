using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AstonFilRouge_API.Enums.Enumerables;

namespace AstonFilRouge_API.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual User? User { get; set; }
        [Required]
        public int ClubId { get; set; }
        [ForeignKey("ClubId")]
        public virtual Club? Club { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public BillingPeriod BillingPeriod { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndCommitmentDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
