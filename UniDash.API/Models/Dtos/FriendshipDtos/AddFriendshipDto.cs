using UniDash.API.Models.Domain;

namespace UniDash.API.Models.Dtos.FriendshipDtos
{
    public class AddFriendshipDto
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsAccepted { get; set; }
    }
}
