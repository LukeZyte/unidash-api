using UniDash.API.Models.Domain;
using UniDash.API.Models.Dtos.UserDtos;

namespace UniDash.API.Models.Dtos.FriendshipDtos
{
    public class FriendshipInviteesDto
    {
        public UserSimpleDto User { get; set; } // Osoba dodawana
        public DateTime? CreatedAt { get; set; }
        public bool IsAccepted { get; set; }
    }
}
