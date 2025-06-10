using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.IssueRouting.Prefix)]
    public class IssueController : AppController
    {
        public IssueController(IMediator mediator) : base(mediator) { }

        #region Queries
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllIssuesAsync()
        {
            var result = await _mediator.Send(new GetAllIssuesQuery());
            return NewResult(result);
        }
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIssueByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetIssueByIdQuery(id));
            return NewResult(result);
        }
        #endregion

        #region Commands
        [Authorize(Roles = "User")]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateIssue([FromForm] CreateIssueCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditIssue([FromForm] UpdateIssueCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIssue([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteIssueCommand(id));
            return NewResult(result);
        }
        #endregion
    }
}
