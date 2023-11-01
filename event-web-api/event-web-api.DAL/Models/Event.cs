namespace event_web_api.DAL.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Theme { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }

        public Guid SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
    }
}
