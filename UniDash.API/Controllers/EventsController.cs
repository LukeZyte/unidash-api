using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniDash.API.Models.Domain;
using UniDash.API.Models.Dtos.EventDtos;
using UniDash.API.Repositories.EventRepository;

namespace UniDash.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController(IEventRepository eventRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await eventRepository.GetAllAsync();
            var eventsDto = mapper.Map<List<EventDto>>(events);
            return Ok(eventsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetAllUserEvents([FromRoute] Guid id)
        {
            var events = await eventRepository.GetAllUserEventsAsync(id);
            var eventsDto = mapper.Map<List<EventDto>>(events);
            return Ok(eventsDto);
        }

        [HttpGet]
        [Route("with-shared/{id:Guid}")]
        public async Task<IActionResult> GetAllUserAndFriendsEvents([FromRoute] Guid id)
        {
            var events = await eventRepository.GetAllUserAndFriendsEventsAsync(id);
            var eventsDto = mapper.Map<List<EventDto>>(events);
            return Ok(eventsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEventDto addEvent)
        {
            var newEvent = mapper.Map<Event>(addEvent);
            await eventRepository.CreateAsync(newEvent);

            var eventDto = mapper.Map<EventDto>(newEvent);
            return Ok(eventDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var deletedEvent = await eventRepository.DeleteByIdAsync(id);
            if (deletedEvent is null)
            {
                return NotFound();
            }
            return Ok(deletedEvent);
        }
    }
}
