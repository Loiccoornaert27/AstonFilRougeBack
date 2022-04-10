namespace AstonFilRouge_API.Enums
{
    public class Enumerables
    {
        public enum BillingPeriod
        {
            Monthly,
            Annually
        }
        public enum CourseStatus
        {
            Pending,
            Planned,
            Cancelled,
            InProgress,
            Over
        }
        public enum CourseType
        {
            Access,
            Individual,
            Collective
        }

        public enum Day
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public enum ReservationStatus
        {
            Requested,
            Rejected,
            Validated
        }

        [Flags]
        public enum Role
        {
            Member = 1,
            Coach = 2,
            Manager = 4,
            SuperAdmin = 8
        }
    }
}
