using Microsoft.EntityFrameworkCore;
using UniDash.API.Data;
using UniDash.API.Models.Domain;

namespace UniDash.API.Repositories.UserRepository
{
    public class SQLUserRepository(UniDashDbContext dbContext) : IUserRepository
    {
        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users
                .Include(u => u.Events)
                .ThenInclude(u => u.EventType)
                .Include(u => u.Inviters)
                .ThenInclude(f => f.Friend)
                .Include(u => u.Invitees)
                .ThenInclude(f => f.User)
                .ToListAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteByIdAsync(Guid id)
        {
            var existingUser = await dbContext.Users.Include(u => u.Inviters).Include(u => u.Invitees).FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser is null)
            {
                return null;
            }
            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
