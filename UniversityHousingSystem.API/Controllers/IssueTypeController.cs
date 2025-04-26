using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    [Route(Router.IssueTypeRouting.Prefix)] // 🔹 Base route added
    public class IssueTypeController : AppController
    {
        public IssueTypeController(IMediator mediator) : base(mediator) { }

        #region Queries

        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBuildingsAsync()
        {
            var result = await _mediator.Send(new GetAllIssueTypeQuery());
            return NewResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBuildingByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetIssueTypeByIdQuery(id)); // ✅ Use constructor
            return NewResult(result);
        }

       

        #endregion

        #region Commands


        #endregion
    }
}

