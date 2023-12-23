using MyInsurance.Application.Helpers.Exceptions;
using MyInsurance.Domain.Resources;

namespace MyInsurance.Application.Models.DTOs
{
    public class CreateRequestDTO
    {
        private List<CreateRequestDetailDTO> _requestDetails;
        public required long UserId { get; set; }
        public required string Title { get; set; }

        public required List<CreateRequestDetailDTO> RequestDetails
        {
            get => _requestDetails;
            set
            {
                if (value.Count == 0)
                {
                    throw new GeneralException(Messages.CoverageNumberMinimumEntry);
                }

                var duplicateIds = value.GroupBy(x => x.CoverageId)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key).ToList();

                if (duplicateIds.Any())
                {
                    throw new GeneralException(Messages.CoverageDuplicate);
                }

                _requestDetails = value;
            }
        }

        //This is a SimpleConverter via Automapper :D
        /*public InsuranceRequest ToInsuranceRequest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateRequestDetailDTO, InsuranceRequestDetail>();
                cfg.CreateMap<CreateRequestDTO, InsuranceRequest>()
                    .ForMember(dest => dest.RequestDetails, act => act.MapFrom(src => src.RequestDetails));
            });

            return new Mapper(config).Map<InsuranceRequest>(this);
        }*/
    }

}
