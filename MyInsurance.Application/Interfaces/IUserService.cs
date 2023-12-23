using MyInsurance.Application.Models.DTOs;
using MyInsurance.Domain.Entities;

namespace MyInsurance.Application.Interfaces
{
    public interface IUserService
    {
        Task<Users> CreateUserAsync(CreateUserDTO model);
        Task<Users> GetUsersAsync(GetUserDTO model);
    }
}
