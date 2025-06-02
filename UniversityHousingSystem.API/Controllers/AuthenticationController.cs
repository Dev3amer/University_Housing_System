using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Authentication.Commands.Models;
using UniversityHousingSystem.Core.Features.Authentication.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace MovieReservationSystem.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppController
    {
        #region Constructors
        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }
        #endregion
        #region Queries Actions
        [Authorize]
        [HttpPost(Router.AuthenticationRouting.ValidateToken)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateToken([FromForm] GetAccessTokenValidityQuery model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        #endregion

        #region Commands Actions
        [HttpPost(Router.AuthenticationRouting.SignIn)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpPost(Router.AuthenticationRouting.RefreshToken)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        #endregion
    }
}
