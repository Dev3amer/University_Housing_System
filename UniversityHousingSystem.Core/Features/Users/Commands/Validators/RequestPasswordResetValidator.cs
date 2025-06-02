using FluentValidation;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Users.Commands.Models;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;

namespace UniversityHousingSystem.Core.Features.Users.Commands.Validators
{
    public class RequestPasswordResetValidator : AbstractValidator<RequestPasswordResetCommand>
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructors
        public RequestPasswordResetValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            ApplyValidationRules();
            ApplyCustomRules();
        }
        #endregion

        private void ApplyValidationRules()
        {
            RuleFor(r => r.Email)
                .NotNull().WithMessage(SharedResourcesKeys.NotNull)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage($"{SharedResourcesKeys.InvalidEmail}");
        }
        private void ApplyCustomRules()
        {
            RuleFor(r => r.Email).MustAsync(async (key, CancellationToken) =>
            {
                return await _userManager.FindByEmailAsync(key) is not null;
            }).WithMessage(SharedResourcesKeys.EmailNotFound);
        }
    }
}
