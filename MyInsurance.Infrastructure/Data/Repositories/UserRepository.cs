using System.Reflection.Metadata;
using Mapster;
using Microsoft.EntityFrameworkCore;
using MyInsurance.Application.Helpers.Exceptions;
using MyInsurance.Domain.Entities;
using MyInsurance.Domain.Interfaces;
using MyInsurance.Domain.Resources;
using MyInsurance.Infrastructure.Entities;
using MyInsurance.Infrastructure.Helper;

namespace MyInsurance.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Users> CreateUserAsync(Users model)
        {
            try
            {
                var entity = model.Adapt<UsersEntity>();
                await _appDbContext.Users.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                //TODO: Check Why Increase Identity Seed

                return entity.Adapt<Users>();
            }
            catch (Exception ex)
            {
                throw new GeneralException(Messages.GeneralSavingError);
            }
        }

        public async Task<Users?> GetUsersAsync(string nationalCode)
        {
            if (await _appDbContext.Users.Where(q => q.NationalCode == nationalCode).FirstOrDefaultAsync() is var entity && entity != null)
            {
                return entity.Adapt<Users>();
            }

            return null;
        }

        public async Task<Users?> GetUsersAsync(long userId)
        {
            if (await _appDbContext.Users.Where(q => q.Id == userId).FirstOrDefaultAsync() is var user && user != null)
            {
                return user.Adapt<Users>();
            }

            return null;
        }
    }
}
