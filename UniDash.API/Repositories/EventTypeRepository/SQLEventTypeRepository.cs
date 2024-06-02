using Microsoft.EntityFrameworkCore;
using UniDash.API.Data;
using UniDash.API.Models.Domain;

namespace UniDash.API.Repositories.EventTypeRepository
{
    public class SQLEventTypeRepository(UniDashDbContext dbContext) : IEventTypeRepository
    {
        public async Task<List<EventType>> GetAllAsync()
        {
            return await dbContext.EventTypes.ToListAsync();
        }

        public async Task<EventType> CreateAsync(EventType eventType)
        {
            await dbContext.EventTypes.AddAsync(eventType);
            await dbContext.SaveChangesAsync();
            return eventType;
        }

        public async Task<EventType?> DeleteByIdAsync(Guid id)
        {
            var existingEventType = await dbContext.EventTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEventType is null)
            {
                return null;
            }
            dbContext.EventTypes.Remove(existingEventType);
            await dbContext.SaveChangesAsync();
            return existingEventType;
        }
    }
}
