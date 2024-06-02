using UniDash.API.Models.Domain;

namespace UniDash.API.Models.Dtos.EventDtos
{
    public class EventSimpleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public bool IsPublic { get; set; }

        public EventType? EventType { get; set; }
    }
}
