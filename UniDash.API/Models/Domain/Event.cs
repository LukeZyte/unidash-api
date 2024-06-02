namespace UniDash.API.Models.Domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public bool IsPublic { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid? EventTypeId { get; set; }
        public EventType? EventType { get; set; }
    }
}
