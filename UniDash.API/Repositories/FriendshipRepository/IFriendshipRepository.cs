using UniDash.API.Models.Domain;

namespace UniDash.API.Repositories.FriendshipRepository
{
    public interface IFriendshipRepository
    {
        Task<Friendship> AddFriendRequestAsync(Friendship friendship);
        Task<Friendship?> AcceptFriendRequestAsync(Guid userId, Guid friendId);
        Task<Friendship?> CancelFriendRequestAsync(Guid userId, Guid friendId);
    }
}
