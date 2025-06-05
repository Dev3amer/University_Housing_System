using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IStudentRegistrationService
    {
        Task<StudentRegistrationCode?> GetByCodeAsync(string code);
        Task<StudentRegistrationCode?> GetByPaymentIntentIdAsync(string paymentIntentId);
        Task<StudentRegistrationCode> CreateAsync(StudentRegistrationCode codeEntry);
        Task<StudentRegistrationCode> UpdateAsync(StudentRegistrationCode codeEntry);
        string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
