using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Users.Commands.Models;
using UniversityHousingSystem.Core.Features.Users.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace MovieReservationSystem.Core.Features.Users.Commands.Handler
{
    public class UserCommandsHandler : ResponseHandler,
        IRequestHandler<EditUserCommand, Response<GetUserByIdResponse>>,
        IRequestHandler<DeleteUserCommand, Response<bool>>,
        IRequestHandler<ChangePasswordCommand, Response<bool>>,
        IRequestHandler<RequestPasswordResetCommand, Response<bool>>,
        IRequestHandler<ResetPasswordCommand, Response<bool>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        #endregion

        #region Constructors
        public UserCommandsHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IUserService userService, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userService = userService;
            _currentUserService = currentUserService;
        }
        #endregion

        #region Actions
        public async Task<Response<GetUserByIdResponse>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var oldUser = await _userManager.FindByIdAsync(request.Id);
            var user = _mapper.Map(request, oldUser);

            var updatedUser = await _userManager.UpdateAsync(user);
            if (!updatedUser.Succeeded)
                return BadRequest<GetUserByIdResponse>(updatedUser.Errors.FirstOrDefault().Description);

            var userMappedIntoResponse = new GetUserByIdResponse
            {
                FullName = $"{user.Student.FirstName} {user.Student.SecondName} {user.Student.ThirdName} {user.Student.FourthName}",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };
            return Success(userMappedIntoResponse);
        }

        public async Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user is null)
                return NotFound<bool>(SharedResourcesKeys.NotFound);

            var isDeleted = await _userManager.DeleteAsync(user);
            if (!isDeleted.Succeeded)
                return BadRequest<bool>(isDeleted.Errors.FirstOrDefault().Description);

            return Deleted<bool>();
        }

        public async Task<Response<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userManager.Users
                .Where(u => u.Id == _currentUserService.GetUserId())
                .FirstOrDefault();

            if (currentUser is null)
                return Unauthorized<bool>(SharedResourcesKeys.UnAuthorized);

            var isPasswordChanged = await _userManager.ChangePasswordAsync(currentUser, request.OldPassword, request.ConfirmPassword);

            if (!isPasswordChanged.Succeeded)
                return BadRequest<bool>(isPasswordChanged.Errors.FirstOrDefault().Description);

            return Success<bool>(true);
        }
        public async Task<Response<bool>> Handle(RequestPasswordResetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.SendResetUserPasswordCode(request.Email);

                return result ? Success(result) : BadRequest<bool>(SharedResourcesKeys.TryAgain);
            }
            catch (Exception ex)
            {
                return BadRequest<bool>(ex.Message);
            }
        }
        public async Task<Response<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!await _userService.ValidatePasswordResetCode(request.Email, request.ResetCode))
                    return BadRequest<bool>(SharedResourcesKeys.IncorrectCode);
                var result = await _userService.ResetUserPassword(request.ResetCode, request.Password);

                if (string.IsNullOrEmpty(result))
                    return Success(true);
                else
                    return BadRequest<bool>(result);
            }
            catch (Exception)
            {
                return BadRequest<bool>(SharedResourcesKeys.TryAgain);
            }
        }
        #endregion
    }
}
