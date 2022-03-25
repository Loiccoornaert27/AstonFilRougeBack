using static AstonFilRouge_API.Enums.Enumerables;

namespace AstonFilRouge_API.Models
{
    public class Course
    {
        public int Id { get; set; }
        public CourseType Type { get; set; }
        public DateTime Date { get; set; }
        public int StartHour { get => Date.Hour; }
        public int EndHour { get; set; }  
        public CourseStatus Status { get; set; }
        public int ClubId { get; set; }
        public Address Address { get; set; }
        public Coach CoachId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
