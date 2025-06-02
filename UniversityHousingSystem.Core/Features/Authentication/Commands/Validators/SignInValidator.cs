using FluentValidation;
using UniversityHousingSystem.Core.Features.Authentication.Commands.Models;
using UniversityHousingSystem.Data.Resources;

namespace UniversityHousingSystem.Core.Features.Authentication.Commands.Validators
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        #region Fields
        #endregion

        #region Constructors
        public SignInValidator()
        {
            ApplyValidationRules();
        }
        #endregion
        private void ApplyValidationRules()
        {
            RuleFor(s => s.UserName)
                .NotNull().WithMessage(SharedResourcesKeys.NotNull)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty);

            RuleFor(s => s.Password)
                .NotNull().WithMessage(SharedResourcesKeys.NotNull)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty);
        }
    }
}
