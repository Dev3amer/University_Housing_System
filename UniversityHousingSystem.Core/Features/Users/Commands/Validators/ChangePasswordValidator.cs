using FluentValidation;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Users.Commands.Models;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;

namespace UniversityHousingSystem.Core.Features.Users.Commands.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructors
        public ChangePasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion


        private void ApplyValidationRules()
        {
            RuleFor(u => u.ConfirmPassword)
                .NotNull().WithMessage(SharedResourcesKeys.NotNull)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .Equal(u => u.Password).WithMessage($"{SharedResourcesKeys.InvalidConfirmPassword}");
        }
        private void ApplyCustomValidationRules()
        {
            //Check if user is Exist by Id
            RuleFor(u => u.Id).MustAsync(async (key, CancellationToken) =>
            {
                return await _userManager.FindByIdAsync(key) is not null;
            }).WithMessage(SharedResourcesKeys.Invalid);
        }
    }
}
