using FluentValidation;
using UniversityHousingSystem.Core.Features.Users.Commands.Models;
using UniversityHousingSystem.Data.Resources;

namespace UniversityHousingSystem.Core.Features.Users.Commands.Validators
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
    {
        #region Fields
        #endregion

        #region Constructors
        public ResetPasswordValidator()
        {
            ApplyValidationRules();
        }
        #endregion

        private void ApplyValidationRules()
        {
            RuleFor(u => u.ResetCode)
            .NotNull().WithMessage(SharedResourcesKeys.NotNull)
            .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
            .MaximumLength(6).WithMessage($"{SharedResourcesKeys.MaxLength} 6");


            RuleFor(u => u.Password)
                .NotNull().WithMessage(SharedResourcesKeys.NotNull)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty);

            RuleFor(u => u.ConfirmPassword)
                .NotNull().WithMessage(SharedResourcesKeys.NotNull)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .Equal(u => u.Password).WithMessage($"{SharedResourcesKeys.InvalidConfirmPassword}");
        }
    }
}
