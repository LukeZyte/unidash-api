using UniDash.API.Models.Domain;
using UniDash.API.Models.Dtos;

namespace UniDash.API.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User?> DeleteByIdAsync(Guid id);
    }
}
