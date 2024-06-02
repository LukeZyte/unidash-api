using Microsoft.EntityFrameworkCore;
using UniDash.API.Data;
using UniDash.API.Models.Domain;

namespace UniDash.API.Repositories.FriendshipRepository
{
    public class SQLFriendshipRepository(UniDashDbContext dbContext) : IFriendshipRepository
    {
        public async Task<Friendship> AddFriendRequestAsync(Friendship friendship)
        {
            await dbContext.Friendships.AddAsync(friendship);
            await dbContext.SaveChangesAsync();
            return friendship;
        }

        public async Task<Friendship?> AcceptFriendRequestAsync(Guid userId, Guid friendId)
        {
            var friendship = await dbContext.Friendships
                .FirstOrDefaultAsync(f => f.UserId == userId && f.FriendId == friendId);
            if (friendship is null)
            {
                return null;
            }

            friendship.IsAccepted = true;
            await dbContext.SaveChangesAsync();
            return friendship;
        }

        public async Task<Friendship?> CancelFriendRequestAsync(Guid userId, Guid friendId)
        {
            var friendship = await dbContext.Friendships
                .FirstOrDefaultAsync(f => f.UserId == userId && f.FriendId == friendId);
            if (friendship is null)
            {
                return null;
            }
            dbContext.Friendships.Remove(friendship);
            await dbContext.SaveChangesAsync();
            return friendship;
        }
    }
}
