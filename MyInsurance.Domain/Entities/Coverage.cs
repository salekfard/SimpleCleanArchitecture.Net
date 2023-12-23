namespace MyInsurance.Domain.Entities
{
    public class Coverage
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public int MinCapital { get; set; }

        public int MaxCapital { get; set; }

        public decimal CalculationPercentage { get; set; }
    }
}
