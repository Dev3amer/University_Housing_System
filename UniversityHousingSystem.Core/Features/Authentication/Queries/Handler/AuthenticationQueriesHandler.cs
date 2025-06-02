using MediatR;
using UniversityHousingSystem.Core.Features.Authentication.Queries.Models;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Authentication.Queries.Handler
{
    public class AuthenticationQueriesHandler : ResponseHandler,
        IRequestHandler<GetAccessTokenValidityQuery, Response<string>>
    {
        #region Fields
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;

        #endregion

        #region Constructors
        public AuthenticationQueriesHandler(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }
        #endregion

        public async Task<Response<string>> Handle(GetAccessTokenValidityQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ValidateAccessTokenAsync(request.AccessToken);
            if (result != null)
                return Unauthorized<string>(result);
            return Success("Valid Token");
        }

    }
}
