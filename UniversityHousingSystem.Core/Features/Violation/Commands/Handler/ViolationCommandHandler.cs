using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Buildings.Commands.Handler
{
    public class ViolationCommandHandler : ResponseHandler,
      IRequestHandler<CreateViolationCommand, Response<GetViolationByIdResponse>>,
     IRequestHandler<UpdateViolationCommand, Response<GetViolationByIdResponse>>,
     IRequestHandler<DeleteViolationCommand, Response<bool>>
    {
        #region Fields
        private readonly IViolationService _ViolationService;
        #endregion

        #region Constructor
        public ViolationCommandHandler(
            IViolationService ViolationService)
        {
            _ViolationService = ViolationService;
        
        }
        #endregion

        #region Handlers
        public async Task<Response<GetViolationByIdResponse>> Handle(CreateViolationCommand request, CancellationToken cancellationToken)
        {
            // Create the new violation object
            var violation = new Violation
            {
                ViolationDate = request.ViolationDate,
                StudentHistoryId=request.StudentHistoryId,
                ViolationTypeId=request.ViolationTypeId,
            };

            // Call the service to create the violation
            var createdviolation = await _ViolationService.CreateAsync(violation);

            // Prepare the response
            var response = new GetViolationByIdResponse
            {
                ViolationId = createdviolation.ViolationId,
                ViolationDate = createdviolation.ViolationDate,
                StudentHistoryId = createdviolation.StudentHistoryId,
                ViolationTypeId = createdviolation.ViolationTypeId,
            };

            return Success(response);
        }
       
        
        
        public async Task<Response<GetViolationByIdResponse>> Handle(UpdateViolationCommand request, CancellationToken cancellationToken)
        {
            var violation = await _ViolationService.GetAsync(request.ViolationId);
            if (violation == null)
                return NotFound<GetViolationByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Violation)));

            violation.StudentHistoryId = request.StudentHistoryId;
            violation.ViolationTypeId = request.ViolationTypeId;
          //// need description

            var updatedviolation = await _ViolationService.UpdateAsync(violation);

            var response = new GetViolationByIdResponse
            {
                ViolationId = updatedviolation.ViolationId,
                StudentHistoryId = updatedviolation.StudentHistoryId,
                ViolationTypeId= updatedviolation.ViolationTypeId
            };

            return Success(response);
        }
        public async Task<Response<bool>> Handle(DeleteViolationCommand request, CancellationToken cancellationToken)
        {
            var violation = await _ViolationService.GetAsync(request.ViolationId);

            if (violation == null)
                return NotFound<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Violation)));

            var result = await _ViolationService.DeleteAsync(violation);
            return Success(result);
        }


        #endregion
    }
}

