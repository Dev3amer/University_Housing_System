using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.IssueTypeRouting.Prefix)]
    public class IssueTypeController : AppController
    {
        public IssueTypeController(IMediator mediator) : base(mediator) { }

        #region Queries
        //[Authorize]
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllIssuesTypesAsync()
        {
            var result = await _mediator.Send(new GetAllIssueTypeQuery());
            return NewResult(result);
        }
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIssueTypeByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetIssueTypeByIdQuery(id));
            return NewResult(result);
        }
        #endregion

        #region Commands
        [Authorize]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateIssueType([FromForm] CreateIssueTypeCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditIssueType([FromForm] UpdateIssueTypeCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIssueType([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteIssueTypeCommand { IssueTypeId = id });
            return NewResult(result);
        }

        #endregion
    }
}

