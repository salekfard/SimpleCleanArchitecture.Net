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
    public class CoverageRepository : ICoverageRepository
    {
        private readonly AppDbContext _appDbContext;

        public CoverageRepository(AppDbContext appDbContext,IUserRepository userRepository)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateRequestAsync(InsuranceRequest model)
        {
            try
            {
                var entity = model.Adapt<InsuranceRequestEntity>();
                await _appDbContext.InsuranceRequests.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.GetEfError() == EfError.DuplicateRecord)
                {
                    throw new GeneralException(Messages.CoverageDuplicate);
                }

                throw new GeneralException(Messages.GeneralSavingError);
            }
        }

        public async Task<List<Coverage>> GetAllCoveragesAsync()
        {
            var entities = await _appDbContext.Coverages.ToListAsync();
            return entities.Adapt<List<Coverage>>();
        }

        public async Task<List<InsuranceRequest>?> GetAllRequestsAsync(long userId)
        {
            //For One Table
            /*if (await _appDbContext.InsuranceRequests.Where(q => q.UserId == userId).Include(q => q.RequestDetails).ToListAsync() is var entities && entities?.Count > 0)
            {
                return entities.Adapt<List<InsuranceRequest>>();
                
            }*/

            var insuranceRequests = await _appDbContext.InsuranceRequests.Where(q => q.UserId == userId)
                .Include(ir => ir.RequestDetails)
                .ThenInclude(rd => rd.CoverageEntity)
                .Select(request => new InsuranceRequestEntity
                {
                    Id = request.Id,
                    UserId = request.UserId,
                    Title = request.Title,
                    RequestDetails = request.RequestDetails.Select(re => new InsuranceRequestDetailEntity
                    {
                        Id = re.Id,
                        CoverageId = re.CoverageId,
                        CoverageValue = re.CoverageValue,
                        RequestId = re.RequestId,
                        AdditionalData = new InsuranceRequestDetailEntity.Additional()
                        {
                            CoverageTitle = re.CoverageEntity.Title,
                            CoveragePercentage = re.CoverageEntity.CalculationPercentage
                        }
                    }).ToList()
                })
                .ToListAsync();

            if (insuranceRequests?.Count > 0)
            {
                return insuranceRequests.Adapt<List<InsuranceRequest>>();
            }

            return null;
        }
    }
}
