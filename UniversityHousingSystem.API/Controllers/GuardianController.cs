using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Guardian.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class GuardianController : AppController
    {
        public GuardianController(IMediator mediator) : base(mediator) { }

        #region Queries

        [HttpGet(Router.GuardianRouting.List)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGuardiansAsync()
        {
            var result = await _mediator.Send(new GetAllGuardiansQuery());
            return NewResult(result);
        }
        [HttpGet(Router.GuardianRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGuardianByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetGuardianByIdQuery(id));
            return NewResult(result);
        }

        [HttpGet(Router.GuardianRouting.paginated)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGuardiansPaginatedList([FromQuery] GetGuardiansPaginatedListQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        #endregion

        #region Commands

        //[HttpPost("Create")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> CreateGuardian([FromForm] CreateGuardianCommand model)
        //{
        //    var result = await _mediator.Send(model);
        //    return NewResult(result);
        //}

        //[HttpPut("Update")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> EditGuardian([FromForm] UpdateGuardianCommand model)
        //{
        //    var result = await _mediator.Send(model);
        //    return NewResult(result);
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteGuardian([FromRoute] int id)
        //{
        //    var result = await _mediator.Send(new DeleteGuardianCommand { GuardianId = id });
        //    return NewResult(result);
        //}

        #endregion
    }
}

