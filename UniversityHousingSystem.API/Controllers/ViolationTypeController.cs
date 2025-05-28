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
    [Route(Router.ViolationTypeRouting.Prefix)] // 🔹 Base route added
    public class ViolationTypeController : AppController
    {
        public ViolationTypeController(IMediator mediator) : base(mediator) { }

        #region Queries

        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllViolationsTypesAsync()
        {
            var result = await _mediator.Send(new GetAllViolationTypeQuery());
            return NewResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetViolationTypeByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetViolationTypeByIdQuery(id)); // ✅ Use constructor
            return NewResult(result);
        }



        #endregion

        #region Commands

       

        #endregion
    }
}

