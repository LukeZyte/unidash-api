using UniDash.API.Models.Domain;
using UniDash.API.Models.Dtos.EventDtos;
using UniDash.API.Models.Dtos.FriendshipDtos;

namespace UniDash.API.Models.Dtos.UserDtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<EventSimpleDto> Events { get; set; }

        // List of users who initiated the "friendship"
        public virtual List<FriendshipInvitersDto> Inviters { get; set; }
        // List of users who where invited to the "friendship"
        public virtual List<FriendshipInviteesDto> Invitees { get; set; }
    }
}
