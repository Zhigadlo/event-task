namespace Entities.DatatTransferObjects
{
    public class EventForCreationDto
    {
        public string Theme { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }

        public Guid SpeakerId { get; set; }
    }
}
