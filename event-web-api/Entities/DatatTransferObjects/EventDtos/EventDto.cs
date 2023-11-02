using Entities.DatatTransferObjects.SpeakerDtos;

namespace Entities.DatatTransferObjects.EventDtos
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Theme { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }

        public SpeakerDto Speaker { get; set; }
    }
}
