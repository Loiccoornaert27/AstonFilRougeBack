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
            Collective,
            Home
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

        public enum Role
        {
            Guest,
            Member,
            Coach,
            Manager,
            SuperAdmin,
            All
        }
    }
}
