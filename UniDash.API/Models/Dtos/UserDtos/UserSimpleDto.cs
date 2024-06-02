using UniDash.API.Models.Domain;

namespace UniDash.API.Models.Dtos.UserDtos
{
    public class UserSimpleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
