using MyInsurance.Domain.Entities;

namespace MyInsurance.Domain.Interfaces
{
    public interface ICoverageRepository
    {
        Task CreateRequestAsync(InsuranceRequest model);
        Task<List<InsuranceRequest>?> GetAllRequestsAsync(long userId);
        Task<List<Coverage>> GetAllCoveragesAsync();
    }
}
