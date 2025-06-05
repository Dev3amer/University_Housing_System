using Microsoft.Extensions.Configuration;
using Stripe;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentRegistrationService _studentRegistrationService;

        public PaymentService(IConfiguration configuration, IStudentRegistrationService studentRegistrationService)
        {
            _configuration = configuration;
            _studentRegistrationService = studentRegistrationService;
        }

        public async Task<StudentRegistrationCode?> CreateOrUpdatePaymentIntent(string code)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

            var registrationCode = await _studentRegistrationService.GetByCodeAsync(code);
            if (registrationCode == null || registrationCode.IsPaid || registrationCode.IsUsed)
                return null;

            var amount = 5000; // example: 50 EGP
            var currency = "egp";
            var service = new PaymentIntentService();

            if (string.IsNullOrEmpty(registrationCode.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = currency,
                    PaymentMethodTypes = new List<string> { "card" },
                    Metadata = new Dictionary<string, string>
                    {
                        { "registration_code", registrationCode.Code },
                        { "email", registrationCode.Email }
                    }
                };

                var paymentIntent = await service.CreateAsync(options);


                registrationCode.PaymentIntentId = paymentIntent.Id;
                registrationCode.ClientSecret = paymentIntent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = amount
                };

                await service.UpdateAsync(registrationCode.PaymentIntentId, options);
            }

            return await _studentRegistrationService.UpdateAsync(registrationCode);
        }

        public async Task UpdatePaymentStatus(string paymentIntentId, bool isSucceeded)
        {
            var registration = await _studentRegistrationService.GetByPaymentIntentIdAsync(paymentIntentId);
            if (registration == null) return;

            if (isSucceeded)
            {
                registration.IsPaid = true;
                await _studentRegistrationService.UpdateAsync(registration);
            }
        }
    }

}
