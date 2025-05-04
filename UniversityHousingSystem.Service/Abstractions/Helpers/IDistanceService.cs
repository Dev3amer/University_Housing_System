namespace UniversityHousingSystem.Service.Abstractions.Helpers
{
    public interface IDistanceService
    {
        Task<double?> GetDrivingDistanceInKmAsync(string fromAddress, string toAddress);
    }

}
