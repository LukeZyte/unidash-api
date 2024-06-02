using UniDash.API.Models.Domain;
using UniDash.API.Models.Dtos.EventTypeDtos;
using UniDash.API.Models.Dtos.UserDtos;

namespace UniDash.API.Models.Dtos.EventDtos
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public bool IsPublic { get; set; }

        public UserSimpleDto User { get; set; }
        public EventTypeDto? EventType { get; set; }
    }
}
