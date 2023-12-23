using Mapster;
using MyInsurance.Application.Helpers.Exceptions;
using MyInsurance.Application.Interfaces;
using MyInsurance.Application.Models.DTOs;
using MyInsurance.Domain.Entities;
using MyInsurance.Domain.Interfaces;
using MyInsurance.Domain.Resources;

namespace MyInsurance.Application.Services
{
    public class CoverageService : ICoverageService
    {
        private readonly ICoverageRepository _coverageRepository;
        private readonly IUserRepository _userRepository;

        public CoverageService(ICoverageRepository coverageRepository, IUserRepository userRepository)
        {
            _coverageRepository = coverageRepository;
            _userRepository = userRepository;
        }

        public async Task CreateRequestAsync(CreateRequestDTO model)
        {
            if (await _userRepository.GetUsersAsync(model.UserId) is var user && user != null)
            {
                if (await _coverageRepository.GetAllCoveragesAsync() is var coverages && coverages?.Count > 0)
                {
                    foreach (var request in model.RequestDetails)
                    {
                        if (coverages.Find(x => x.Id == request.CoverageId) is var coverage && coverage != null)
                        {
                            if (request.CoverageValue < coverage.MinCapital || request.CoverageValue > coverage.MaxCapital)
                            {
                                throw new GeneralException(string.Format(Messages.InvalidCoverageRangeValue,
                                     coverage.Title,
                                     coverage.MinCapital.ToString(),
                                     coverage.MaxCapital.ToString()));
                            }
                        }
                        else
                        {
                            throw new GeneralException(Messages.InvalidCoverage);
                        }
                    }
                }
                else
                {
                    throw new GeneralException(Messages.DoNotAnyActiveCoverages);
                }

                var inputModel = model.Adapt<InsuranceRequest>();
                await _coverageRepository.CreateRequestAsync(inputModel);
            }
            else
            {
                throw new GeneralException(Messages.UserNotFound);
            }
        }

        public async Task<ResponseRequestDTO> GetAllRequestsAsync(long userId)
        {
            if (await _userRepository.GetUsersAsync(userId) is var user && user != null)
            {
                if (await _coverageRepository.GetAllRequestsAsync(userId) is var models && models != null)
                {
                    var conf = new TypeAdapterConfig();
                    conf.ForType<InsuranceRequest, ResponseRequestDTO.Request>()
                        .Map(dest => dest.Coverages, src => src.RequestDetails);
                    conf.ForType<InsuranceRequestDetail, ResponseRequestDTO.Request.Coverage>()
                        .Map(dest => dest.CoverageTitle, src => src.AdditionalData.CoverageTitle)
                        .Map(dest => dest.CoveragePercentage, src => src.AdditionalData.CoveragePercentage);


                    var requests = models.Adapt<List<ResponseRequestDTO.Request>>(conf);
                    return new ResponseRequestDTO(requests);
                }
            }
            else
            {
                throw new GeneralException(Messages.UserNotFound);
            }

            throw new GeneralException(Messages.RequestNotFound);
        }
    }
}
