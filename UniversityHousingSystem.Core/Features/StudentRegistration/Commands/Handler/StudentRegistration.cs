using MediatR;
using UniversityHousingSystem.Core.Features.StudentRegistration.Commands.Models;
using UniversityHousingSystem.Core.Features.StudentRegistration.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.StudentRegistration.Commands.Handler
{
    public class StudentRegistration : ResponseHandler,
        IRequestHandler<SendRegistrationCodeToEmail, Response<StudentRegistrationCodeResult>>
    {
        #region Fields
        private readonly IStudentRegistrationService _studentRegistrationService;
        private readonly IPaymentService _paymentService;
        private readonly IEmailService _emailService;
        private readonly IRegistrationPeriodService _registrationPeriodService;
        #endregion

        #region Constructors
        public StudentRegistration(IStudentRegistrationService studentRegistrationService, IEmailService emailService, IPaymentService paymentService, IRegistrationPeriodService registrationPeriodService)
        {
            _studentRegistrationService = studentRegistrationService;
            _emailService = emailService;
            _paymentService = paymentService;
            _registrationPeriodService = registrationPeriodService;
        }
        #endregion

        #region Actions
        public async Task<Response<StudentRegistrationCodeResult>> Handle(SendRegistrationCodeToEmail request, CancellationToken cancellationToken)
        {
            var currentPeriod = await _registrationPeriodService.GetCurrentRegistrationPeriodAsync();
            StudentRegistrationCode code = new StudentRegistrationCode
            {
                Amount = currentPeriod.RegistrationFees,
                Email = request.Email,
                Code = _studentRegistrationService.GenerateRandomCode(10),
                IsUsed = false,
                IsPaid = false,
                CreatedAt = DateTime.UtcNow,
                AllowedTime = currentPeriod.To
            };

            var result = await _studentRegistrationService.CreateAsync(code);
            if (result is null)
            {
                return BadRequest<StudentRegistrationCodeResult>(SharedResourcesKeys.TryAgain);
            }

            try
            {
                await _emailService.SendEmail(request.Email, "", $"Use this code to pay: {code.Code}", "Registration Code");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity<StudentRegistrationCodeResult>(ex.Message);
            }

            await _paymentService.CreateOrUpdatePaymentIntent(code.Code);

            var mappedResult = new StudentRegistrationCodeResult()
            {
                Code = result.Code,
                Amount = result.Amount,
                ClientSecret = result.ClientSecret,
                PaymentIntentId = result.PaymentIntentId,
                Email = result.Email,
                IsPaid = result.IsPaid,
                AllowedTime = result.AllowedTime
            };
            return Success(mappedResult);

        }
        #endregion
    }
}
