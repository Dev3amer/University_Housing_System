using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class StudentRegistrationService : IStudentRegistrationService
    {
        private readonly IStudentRegistrationRepository _studentRegistrationRepository;

        public StudentRegistrationService(IStudentRegistrationRepository studentRegistrationRepository)
        {
            _studentRegistrationRepository = studentRegistrationRepository;
        }

        public async Task<StudentRegistrationCode?> GetByCodeAsync(string code)
        {
            return await _studentRegistrationRepository.GetTableAsTracking()
                .Where(x => x.Code == code)
                .FirstOrDefaultAsync();
        }

        public async Task<StudentRegistrationCode?> GetByPaymentIntentIdAsync(string paymentIntentId)
        {
            return await _studentRegistrationRepository.GetTableAsTracking()
                .Where(x => x.PaymentIntentId == paymentIntentId)
                .FirstOrDefaultAsync();
        }

        public async Task<StudentRegistrationCode> CreateAsync(StudentRegistrationCode codeEntry)
        {
            return await _studentRegistrationRepository.AddAsync(codeEntry);
        }

        public async Task<StudentRegistrationCode> UpdateAsync(StudentRegistrationCode codeEntry)
        {
            return await _studentRegistrationRepository.UpdateAsync(codeEntry);
        }
        public async Task ChangeCodeState(StudentRegistrationCode registrationCode)
        {
            registrationCode.IsUsed = true;
            await _studentRegistrationRepository.UpdateAsync(registrationCode);
        }
        public string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}