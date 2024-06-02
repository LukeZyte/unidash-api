using UniDash.API.Models.Domain;

namespace UniDash.API.Repositories.EventTypeRepository
{
    public interface IEventTypeRepository
    {
        Task<List<EventType>> GetAllAsync();
        Task<EventType> CreateAsync(EventType eventType);
        Task<EventType?> DeleteByIdAsync(Guid id);
    }
}
