using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniDash.API.Models.Domain;
using UniDash.API.Models.Dtos.FriendshipDtos;
using UniDash.API.Repositories.FriendshipRepository;

namespace UniDash.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendshipsController(IFriendshipRepository friendshipRepository, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddFriendRequest([FromBody] AddFriendshipDto addFriendshipDto)
        {
            var newFriendship = mapper.Map<Friendship>(addFriendshipDto);
            await friendshipRepository.AddFriendRequestAsync(newFriendship);

            var friendship = mapper.Map<Friendship>(newFriendship);
            return Ok(friendship);
        }

        [HttpPut("accept")]
        public async Task<IActionResult> AcceptFriendRequest([FromBody] AcceptFriendshipDto acceptFriendshipDto)
        {
            var acceptedFriendship = await friendshipRepository.AcceptFriendRequestAsync(acceptFriendshipDto.UserId, acceptFriendshipDto.FriendId);
            if (acceptedFriendship == null)
            {
                return NotFound();
            }

            var friendshipDto = mapper.Map<AddFriendshipDto>(acceptedFriendship);
            return Ok(friendshipDto);
        }

        [HttpDelete("cancel")]
        public async Task<IActionResult> CancelFriendRequest([FromBody] CancelFriendshipDto cancelFriendshipDto)
        {
            var deletedFriendship = await friendshipRepository.CancelFriendRequestAsync(cancelFriendshipDto.UserId, cancelFriendshipDto.FriendId);
            if (deletedFriendship is null)
            {
                return NotFound();
            }

            var deletedFriendshipDto = mapper.Map<CancelFriendshipDto>(deletedFriendship);
            return Ok(deletedFriendshipDto);
        }
    }
}
