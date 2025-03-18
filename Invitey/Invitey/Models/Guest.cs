namespace Invitey.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Contact {  get; set; }
        public string Relation { get; set; }
        public int MemberCount { get; set; }
        public bool Attendance {  get; set; }
        public bool TransportRequired {  get; set; }
        public bool AccomodationRequired {  get; set; }

        public Occasion OccasionID { get; set; }
        public Occasion OccasionName { get; set; }

    }
}
