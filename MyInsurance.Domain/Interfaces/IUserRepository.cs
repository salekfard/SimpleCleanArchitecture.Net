using MyInsurance.Domain.Entities;

namespace MyInsurance.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> CreateUserAsync(Users model);
        Task<Users?> GetUsersAsync(string nationalCode);
        Task<Users?> GetUsersAsync(long userId);

    }
}
