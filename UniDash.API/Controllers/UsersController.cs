using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniDash.API.Models.Domain;
using UniDash.API.Models.Dtos.UserDtos;
using UniDash.API.Repositories.UserRepository;

namespace UniDash.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserRepository userRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await userRepository.GetAllAsync();
            var usersDto = mapper.Map<List<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUserDto addUserDto)
        {
            var user = mapper.Map<User>(addUserDto);
            await userRepository.CreateAsync(user);

            var userDto = mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var deletedUser = await userRepository.DeleteByIdAsync(id);
            if (deletedUser is null)
            {
                return NotFound();
            }
            return Ok(deletedUser);
        }
    }
}
