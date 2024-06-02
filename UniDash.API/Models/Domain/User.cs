using UniDash.API.Models.Dtos;

namespace UniDash.API.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Event> Events { get; set; }

        // List of users who initiated the "friendship"
        public virtual List<Friendship> Inviters { get; set; }
        // List of users who where invited to the "friendship"
        public virtual List<Friendship> Invitees { get; set; }
    }
}
