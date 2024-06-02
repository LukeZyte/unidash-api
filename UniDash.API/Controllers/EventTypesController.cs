using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniDash.API.Models.Domain;
using UniDash.API.Models.Dtos.EventTypeDtos;
using UniDash.API.Repositories.EventTypeRepository;

namespace UniDash.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypesController(IEventTypeRepository eventTypeRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var eventTypes = await eventTypeRepository.GetAllAsync();
            var eventTypesDto = mapper.Map<List<EventTypeDto>>(eventTypes);
            return Ok(eventTypesDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEventTypeDto addEventType)
        {
            var eventType = mapper.Map<EventType>(addEventType);
            await eventTypeRepository.CreateAsync(eventType);

            var eventTypeDto = mapper.Map<EventTypeDto>(eventType);
            return Ok(eventTypeDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var deletedEventType = await eventTypeRepository.DeleteByIdAsync(id);
            if (deletedEventType is null)
            {
                return NotFound();
            }
            return Ok(deletedEventType);
        }
    }
}
