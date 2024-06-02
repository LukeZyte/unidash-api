using Microsoft.AspNetCore.Mvc;
using UniDash.API.Models.Domain;

namespace UniDash.API.Repositories.EventRepository
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllAsync();
        Task<List<Event>> GetAllUserEventsAsync(Guid id);
        Task<List<Event>> GetAllUserAndFriendsEventsAsync([FromRoute] Guid id);
        Task<Event> CreateAsync(Event newEvent);
        Task<Event?> DeleteByIdAsync(Guid id);
    }
}
