using MyInsurance.Domain.Entities;

namespace MyInsurance.Application.Models.DTOs
{
    public class ResponseRequestDTO(List<ResponseRequestDTO.Request> requests)
    {
        public class Request
        {
            public class Coverage
            {
                public long Id { get; set; }
                public int CoverageId { get; set; }
                public string CoverageTitle { get; set; } = "";
                public int CoverageValue { get; set; }
                public decimal CoveragePercentage {  get; set; }
                public decimal CoveragePrice { get => CoverageValue * CoveragePercentage; }
            }

            public long Id { get; set; }
            public required string Title { get; set; }
            public required List<Coverage> Coverages { get; set; }
            /// <summary>
            /// Sum Of Request.Coverage.CoveragePrice
            /// </summary>
            public decimal SumCoveragePrice { get => Coverages.Sum(x => x.CoveragePrice); }
        }
        public List<Request> Requests { get; } = requests;

        /// <summary>
        /// Sum Of Request.SumCoveragePrice
        /// </summary>
        public decimal TotalCoveragePrice { get => Requests.Sum(x => x.SumCoveragePrice); }
    }
}
