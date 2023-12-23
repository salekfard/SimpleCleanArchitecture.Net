namespace MyInsurance.Application.Models.DTOs
{
    public class CreateRequestDetailDTO
    {
        public required int CoverageId { get; set; }
        public required int CoverageValue { get; set; }
    }

}
