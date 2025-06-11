using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Authentication.Commands.Models;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Helpers.DTOs;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Authentication.Commands.Handler
{
    public class AuthenticationCommandsHandler : ResponseHandler,
        IRequestHandler<SignInCommand, Response<JwtAuthTokenResponse>>,
        IRequestHandler<RefreshTokenCommand, Response<JwtAuthTokenResponse>>

    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;


        #endregion
        #region Constructors
        public AuthenticationCommandsHandler(IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthenticationService authenticationService, IUserService userService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
            _userService = userService;
        }
        #endregion
        public async Task<Response<JwtAuthTokenResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if user Exist by Username
            var user = await _userManager.FindByEmailAsync(request.UserName);
            if (user == null)
                return BadRequest<JwtAuthTokenResponse>(string.Format(SharedResourcesKeys.NotFound, "Email"));

            //Check if Password is true for User
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
                return BadRequest<JwtAuthTokenResponse>(SharedResourcesKeys.IncorrectPassword);

            var response = await _authenticationService.GetJwtTokenAsync(user);

            //return token
            return Success(response);
        }

        public async Task<Response<JwtAuthTokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            //Read Access Token To Get Claims 
            var jwtToken = _authenticationService.ReadJwtToken(request.AccessToken);
            var validationResult = await _authenticationService.ValidateBeforeRenewTokenAsync(jwtToken, request.AccessToken, request.RefreshToken);

            if (validationResult != null)
                return Unauthorized<JwtAuthTokenResponse>(validationResult);


            var userRefreshToken = await _authenticationService.GetUserFullRefreshTokenObjByRefreshToken(request.RefreshToken);
            var result = await _authenticationService.CreateNewAccessTokenByRefreshToken(request.AccessToken, userRefreshToken);
            return Success(result);
        }
    }
}
