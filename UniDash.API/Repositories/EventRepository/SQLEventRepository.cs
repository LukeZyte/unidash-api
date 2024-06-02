using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniDash.API.Data;
using UniDash.API.Models.Domain;
using UniDash.API.Models.Dtos;

namespace UniDash.API.Repositories.EventRepository
{
    public class SQLEventRepository(UniDashDbContext dbContext) : IEventRepository
    {
        public async Task<List<Event>> GetAllAsync()
        {
            return await dbContext.Events.Include(e => e.EventType).Include(e => e.User).ToListAsync();
        }

        public async Task<List<Event>> GetAllUserEventsAsync(Guid id)
        {
            return await dbContext.Events
                .Include(e => e.EventType).Include(e => e.User).Where(e => e.UserId == id).ToListAsync();
        }

        public async Task<List<Event>> GetAllUserAndFriendsEventsAsync([FromRoute] Guid id)
        {
            List<Event> events = await dbContext.Events
                .Include(e => e.EventType).Include(e => e.User).Where(e => e.UserId == id).ToListAsync();
            var usersFriendIds = await dbContext.Friendships
                .Where(f => f.UserId == id || f.FriendId == id)
                .Select(f => f.UserId == id ? f.FriendId : f.UserId)
                .ToListAsync();

            var friendsEvents = await dbContext.Events
                .Where(e => usersFriendIds.Contains(e.UserId))
                .Where(e => e.IsPublic)
                .Include(e => e.EventType).Include(e => e.User)
                .ToListAsync();

            var allEvents = events.Concat(friendsEvents).ToList();
            return allEvents;
        }

        public async Task<Event> CreateAsync(Event newEvent)
        {
            await dbContext.Events.AddAsync(newEvent);
            await dbContext.SaveChangesAsync();
            return newEvent;
        }

        public async Task<Event?> DeleteByIdAsync(Guid id)
        {
            var existingEvent = await dbContext.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEvent is null)
            {
                return null;
            }
            dbContext.Events.Remove(existingEvent);
            await dbContext.SaveChangesAsync();
            return existingEvent;
        }
    }
}
