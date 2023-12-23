using MyInsurance.Application.Models.DTOs;
using MyInsurance.Domain.Entities;

namespace MyInsurance.Application.Interfaces
{
    public interface ICoverageService
    {
        Task CreateRequestAsync(CreateRequestDTO model);
        Task<ResponseRequestDTO> GetAllRequestsAsync(long userId);
    }
}
