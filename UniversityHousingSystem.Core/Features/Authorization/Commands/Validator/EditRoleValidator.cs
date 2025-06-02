using FluentValidation;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Authorization.Commands.Models;
using UniversityHousingSystem.Data.Resources;

namespace UniversityHousingSystem.Core.Features.Authorization.Commands.Validator
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;
        #endregion

        #region Constructors
        public EditRoleValidator(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Actions
        private void ApplyValidationRules()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .NotNull().WithMessage(SharedResourcesKeys.NotNull)
                .MaximumLength(256).WithMessage($"{SharedResourcesKeys.MaxLength} 256");
        }
        private void ApplyCustomValidationRules()
        {
            RuleFor(r => r.Id).MustAsync(async (key, CancellationToken) =>
            {
                return await _roleManager.FindByIdAsync(key) is not null;
            }).WithMessage(SharedResourcesKeys.Invalid);
        }
        #endregion
    }
}
