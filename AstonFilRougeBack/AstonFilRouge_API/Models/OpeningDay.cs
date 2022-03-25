namespace AstonFilRouge_API.Models
{
    public class OpeningDay
    {
        public int Id { get; set; }
        public DateTime Day;
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
    }
}
