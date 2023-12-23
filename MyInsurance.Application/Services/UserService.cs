using Mapster;
using MyInsurance.Application.Helpers.Exceptions;
using MyInsurance.Application.Interfaces;
using MyInsurance.Application.Models.DTOs;
using MyInsurance.Domain.Entities;
using MyInsurance.Domain.Interfaces;
using MyInsurance.Domain.Resources;

namespace MyInsurance.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Users> CreateUserAsync(CreateUserDTO model)
        {
            return await _userRepository.CreateUserAsync(model.Adapt<Users>());
        }

        public async Task<Users> GetUsersAsync(GetUserDTO model)
        {

            if (await _userRepository.GetUsersAsync(model.NationalCode) is var user && user!= null)
            {
                return user;
            }
            throw new GeneralException(Messages.UserNotFound);
        }
    }
}
