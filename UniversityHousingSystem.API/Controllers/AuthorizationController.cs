using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Authorization.Commands.Models;
using UniversityHousingSystem.Core.Features.Authorization.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AuthorizationController : AppController
    {
        #region Constructors
        public AuthorizationController(IMediator mediator) : base(mediator)
        {
        }
        #endregion

        #region Queries Actions
        [HttpGet(Router.AuthorizationRouting.list)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var result = await _mediator.Send(new GetAllRolesQuery());
            return NewResult(result);
        }

        [HttpGet(Router.AuthorizationRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoleByIdAsync(string id)
        {
            var result = await _mediator.Send(new GetRoleByIdQuery() { Id = id });
            return NewResult(result);
        }

        [HttpGet(Router.AuthorizationRouting.GetUserRoles)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserRolesByUserIdAsync(string id)
        {
            var result = await _mediator.Send(new GetUserRolesQuery() { userId = id });
            return NewResult(result);
        }
        #endregion

        #region Commands Actions
        [HttpPost(Router.AuthorizationRouting.CreateRole)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRole([FromForm] CreateRoleCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpPut(Router.AuthorizationRouting.EditRole)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditRole([FromForm] EditRoleCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpPut(Router.AuthorizationRouting.EditUserRoles)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditUserRoles([FromForm] UpdateUserRolesCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }

        [HttpDelete(Router.AuthorizationRouting.DeleteRole)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await _mediator.Send(new DeleteRoleCommand { RoleId = id });
            return NewResult(result);
        }
        #endregion
    }
}
