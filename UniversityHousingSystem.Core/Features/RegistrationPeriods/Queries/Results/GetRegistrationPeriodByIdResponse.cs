namespace UniversityHousingSystem.Core.Features.RegistrationPeriod.Queries.Results
{
    public class GetRegistrationPeriodByIdResponse
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsClosed { get; set; }
        public decimal RegistrationFees { get; set; }
    }
}
