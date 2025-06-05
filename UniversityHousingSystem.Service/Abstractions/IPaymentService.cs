using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IPaymentService
    {
        Task<StudentRegistrationCode?> CreateOrUpdatePaymentIntent(string code);
        Task UpdatePaymentStatus(string paymentIntentId, bool isSucceeded);
    }
}
