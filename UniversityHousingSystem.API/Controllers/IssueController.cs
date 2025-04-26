using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.IssueRouting.Prefix)] // 🔹 Base route added
    public class IssueController : AppController
    {
        public IssueController(IMediator mediator) : base(mediator) { }

        #region Queries

        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllIssuesAsync()
        {
            var result = await _mediator.Send(new GetAllIssuesQuery());
            return NewResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIssueByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetIssueByIdQuery(id)); // ✅ Use constructor
            return NewResult(result);
        }



        #endregion

    }
}

