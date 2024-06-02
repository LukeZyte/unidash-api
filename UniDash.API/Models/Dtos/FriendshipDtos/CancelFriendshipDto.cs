namespace UniDash.API.Models.Dtos.FriendshipDtos
{
    public class CancelFriendshipDto
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
