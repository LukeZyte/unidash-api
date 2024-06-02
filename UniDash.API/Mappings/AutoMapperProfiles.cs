using AutoMapper;
using UniDash.API.Models.Domain;
using UniDash.API.Models.Dtos.EventDtos;
using UniDash.API.Models.Dtos.EventTypeDtos;
using UniDash.API.Models.Dtos.FriendshipDtos;
using UniDash.API.Models.Dtos.UserDtos;

namespace UniDash.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, AddUserDto>().ReverseMap();
            CreateMap<User, UserSimpleDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, AddEventDto>().ReverseMap();
            CreateMap<Event, EventSimpleDto>().ReverseMap();
            CreateMap<EventType, EventTypeDto>().ReverseMap();
            CreateMap<EventType, AddEventTypeDto>().ReverseMap();
            CreateMap<Friendship, FriendshipInviteesDto>().ReverseMap();
            CreateMap<Friendship, FriendshipInvitersDto>().ReverseMap();
            CreateMap<Friendship, AddFriendshipDto>().ReverseMap()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt ?? DateTime.UtcNow));
        }
    }
}
