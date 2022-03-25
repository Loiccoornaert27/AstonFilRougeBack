namespace AstonFilRouge_API.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Capacity { get; set; }
        public int Inside { get; set; }
        public List<OpeningDay> OpeningWeekDays { get; set; }
        public List<DateTime> ExceptionnalClosure { get; set; }
        public Course Planning { get; set; }

    }
}
