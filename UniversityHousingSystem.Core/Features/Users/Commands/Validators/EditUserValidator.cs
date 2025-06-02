using FluentValidation;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Users.Commands.Models;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;

namespace UniversityHousingSystem.Core.Features.Users.Commands.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructors
        public EditUserValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion


        private void ApplyValidationRules()
        {
            RuleFor(u => u.FirstName)
                .NotNull().WithMessage(SharedResourcesKeys.NotNull)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .MaximumLength(256).WithMessage($"{SharedResourcesKeys.MaxLength} 256");

            RuleFor(u => u.LastName)
                .NotNull().WithMessage(SharedResourcesKeys.NotNull)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .MaximumLength(256).WithMessage($"{SharedResourcesKeys.MaxLength} 256");

            RuleFor(u => u.UserName)
                .NotNull().WithMessage(SharedResourcesKeys.NotNull)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .MaximumLength(256).WithMessage($"{SharedResourcesKeys.MaxLength} 256");

            RuleFor(u => u.Email)
            .NotNull().WithMessage(SharedResourcesKeys.NotNull)
            .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage($"{SharedResourcesKeys.InvalidEmail}");


            RuleFor(u => u.PhoneNumber)
            .NotNull().WithMessage(SharedResourcesKeys.NotNull)
            .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
            .Matches(@"^(?:\+?20|0020|0)?1[0125]\d{8}$").WithMessage($"{SharedResourcesKeys.InvalidPhone}");

        }
        private void ApplyCustomValidationRules()
        {
            RuleFor(u => u.Id).MustAsync(async (key, CancellationToken) =>
            {
                return await _userManager.FindByIdAsync(key) is not null;
            }).WithMessage(SharedResourcesKeys.NotFound);

            RuleFor(u => u.UserName).MustAsync(async (model, key, CancellationToken) =>
            {
                var user = await _userManager.FindByNameAsync(key);
                return !(user is not null && model.Id != user.Id);
            }).WithMessage(SharedResourcesKeys.Exist);

            RuleFor(u => u.Email).MustAsync(async (model, key, CancellationToken) =>
            {
                var user = await _userManager.FindByEmailAsync(key);
                return !(user is not null && model.Id != user.Id);
            }).WithMessage(SharedResourcesKeys.Exist);

            RuleFor(u => u.Password).MustAsync(async (model, key, CancellationToken) =>
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                return await _userManager.CheckPasswordAsync(user, key);
            }).WithMessage(SharedResourcesKeys.IncorrectPassword);
        }
    }
}
