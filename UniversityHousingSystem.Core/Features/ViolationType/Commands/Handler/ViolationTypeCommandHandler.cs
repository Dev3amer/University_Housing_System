using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;
using UniversityHousingSystem.Service.Implementation;

namespace UniversityHousingSystem.Core.Features.Buildings.Commands.Handler
{
    public class ViolationTypeCommandHandler : ResponseHandler,
      IRequestHandler<CreateViolationTypeCommand, Response<GetViolationTypeByIdResponse>>
     
    {
        #region Fields
        private readonly IViolationTypeService _violationTypeServiceTypeService;
        #endregion

        #region Constructor
        public ViolationTypeCommandHandler(
            IViolationTypeService violationTypeServiceTypeService)
        {
            _violationTypeServiceTypeService = violationTypeServiceTypeService;
        
        }
        #endregion

        #region Handlers
        public async Task<Response<GetViolationTypeByIdResponse>> Handle(CreateViolationTypeCommand request, CancellationToken cancellationToken)
        {

            // Create the new IssueType object
            var violationType = new ViolationType
            {
                Description = request.Description,
                ViolationLevel=request.ViolationLevel,
                RequiredAmount=request.RequiredAmount
            };

            // Call the service to create the IssueType
            var createdviolationType = await _violationTypeServiceTypeService.CreateAsync(violationType);

            // Prepare the response
            var response = new GetViolationTypeByIdResponse
            {
                ViolationTypeId = createdviolationType.ViolationTypeId,
                ViolationTypeName = createdviolationType.Description,
                ViolationLevel=createdviolationType.ViolationLevel.ToString(),
                RequiredAmount=createdviolationType.RequiredAmount
            };

            return Success(response);
        }
        


        #endregion
    }
}

