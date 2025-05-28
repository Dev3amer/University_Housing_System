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
    [Route(Router.ViolationRouting.Prefix)] // 🔹 Base route added
    public class ViolationController : AppController
    {
        public ViolationController(IMediator mediator) : base(mediator) { }

        #region Queries

        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllViolationsAsync()
        {
            var result = await _mediator.Send(new GetAllViolationsQuery());
            return NewResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetViolationByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetViolationByIdQuery(id)); // ✅ Use constructor
            return NewResult(result);
        }



        #endregion

        #region Commands
       

        #endregion
    }
}

