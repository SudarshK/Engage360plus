namespace Invitey.Models
{
    public class Occasion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Venue {  get; set; }
        public DateTime DateTime { get; set; }
        public int Days {  get; set; }
        public string Description { get; set; }
    }
}
