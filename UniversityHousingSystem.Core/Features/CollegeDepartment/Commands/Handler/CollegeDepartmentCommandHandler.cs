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
    public class CollegeDepartmentCommandHandler : ResponseHandler,
      IRequestHandler<CreateCollegeDepartmentCommand, Response<GetCollegeDepartmentByIdResponse>>,
     IRequestHandler<UpdateCollegeDepartmentCommand, Response<GetCollegeDepartmentByIdResponse>>,
     IRequestHandler<DeleteCollegeDepartmentCommand, Response<bool>>
    {
        #region Fields
        private readonly ICollegeDepartmentService _collegeDepartmentService;
        #endregion

        #region Constructor
        public CollegeDepartmentCommandHandler(
            ICollegeDepartmentService collegeDepartmentService)
        {
            _collegeDepartmentService = collegeDepartmentService;
        
        }
        #endregion

        #region Handlers
        public async Task<Response<GetCollegeDepartmentByIdResponse>> Handle(CreateCollegeDepartmentCommand request, CancellationToken cancellationToken)
        {
            // Get the last department
            var lastDepartment = await _collegeDepartmentService.GetLastCollegeDepartmentAsync();

            // Create the new CollegeDepartment object
            var collegeDepartment = new Data.Entities.CollegeDepartment
            {
                Name = request.Name,
                CollegeId = request.CollegeId
            };

            // Call the service to create the department
            var createdCollegeDepartment = await _collegeDepartmentService.CreateAsync(collegeDepartment);

            // Prepare the response
            var response = new GetCollegeDepartmentByIdResponse
            {
                CollegeDepartmentId = createdCollegeDepartment.CollegeDepartmentId,
                Name = createdCollegeDepartment.Name,
                CollegeId = createdCollegeDepartment.CollegeId,
            };

            return Success(response);
        }
        public async Task<Response<GetCollegeDepartmentByIdResponse>> Handle(UpdateCollegeDepartmentCommand request, CancellationToken cancellationToken)
        {
            var collegeDepartment = await _collegeDepartmentService.GetAsync(request.CollegeDepartmentId);
            if (collegeDepartment == null)
                return NotFound<GetCollegeDepartmentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(CollegeDepartment)));

            collegeDepartment.Name = request.Name;
            collegeDepartment.CollegeId = request.CollegeId;
          

            var updatedCollegeDepartment = await _collegeDepartmentService.UpdateAsync(collegeDepartment);

            var response = new GetCollegeDepartmentByIdResponse
            {
                CollegeDepartmentId = updatedCollegeDepartment.CollegeDepartmentId,
                Name = updatedCollegeDepartment.Name,
                CollegeId=updatedCollegeDepartment.CollegeId
            };

            return Success(response);
        }
        public async Task<Response<bool>> Handle(DeleteCollegeDepartmentCommand request, CancellationToken cancellationToken)
        {
            // Explicitly cast CollegeDepartmentId to byte
            var collegeDepartment = await _collegeDepartmentService.GetAsync(request.CollegeDepartmentId);

            if (collegeDepartment == null)
                return NotFound<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(CollegeDepartment)));

            var result = await _collegeDepartmentService.DeleteAsync(collegeDepartment);
            return Success(result);
        }


        #endregion
    }
}

