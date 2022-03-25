using static AstonFilRouge_API.Enums.Enumerables;

namespace AstonFilRouge_API.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ClubId { get; set; }
        public int Price { get; set; }
        public BillingPeriod BillingPeriod { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndCommitmentDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
