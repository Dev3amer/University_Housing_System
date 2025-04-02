using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
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

        //public async Task<Response<GetCollegeDepartmentByIdResponse>> Handle(CreateCollegeDepartmentCommand request, CancellationToken cancellationToken)
        //{
        //    var collegeDepartment = new CollegeDepartment
        //    {
        //        Name = request.Name,
        //        CollegeId = request.CollegeId,
        //    };

        //    var createdCollegeDepartment = await _collegeDepartmentService.CreateAsync(collegeDepartment);

        //    var response = new GetCollegeDepartmentByIdResponse
        //    {
        //        CollegeDepartmentId = createdCollegeDepartment.CollegeDepartmentId,
        //        Name = createdCollegeDepartment.Name,
        //        CollegeId=createdCollegeDepartment.CollegeId,
        //    };

        //    return Created(response, string.Format(SharedResourcesKeys.Created, nameof(College)));
        //}

        public async Task<Response<GetCollegeDepartmentByIdResponse>> Handle(CreateCollegeDepartmentCommand request, CancellationToken cancellationToken)
        {
            // Get the last department
            var lastDepartment = await _collegeDepartmentService.GetLastCollegeDepartmentAsync();

            // Assign a new ID based on the last department's ID
            byte newId = lastDepartment != null ? (byte)(lastDepartment.CollegeDepartmentId + 1) : (byte)1;

            // Create the new CollegeDepartment object
            var collegeDepartment = new CollegeDepartment
            {
                CollegeDepartmentId = (byte)newId, // Manually assign ID
                Name = request.Name,
                CollegeId = request.CollegeId
            };

            // Call the service to create the department
            var createdCollegeDepartment = await _collegeDepartmentService.CreateAsync(collegeDepartment);

            // Prepare the response
            var response = new GetCollegeDepartmentByIdResponse
            {
                CollegeDepartmentId = (byte)createdCollegeDepartment.CollegeDepartmentId,
                Name = createdCollegeDepartment.Name,
                CollegeId = createdCollegeDepartment.CollegeId,
            };

            return Success(response);
        }




        // ********** Update Guardian **********
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
                Name = updatedCollegeDepartment.Name,
                CollegeId=updatedCollegeDepartment.CollegeId
              //  Departments = updatedCollege.Departments?.Select(d => d.Name).ToList()

            };

            return Success(response);
        }
        //delete
        public async Task<Response<bool>> Handle(DeleteCollegeDepartmentCommand request, CancellationToken cancellationToken)
        {
            // Explicitly cast CollegeDepartmentId to byte
            var collegeDepartment = await _collegeDepartmentService.GetAsync((byte)request.CollegeDepartmentId);

            if (collegeDepartment == null)
                return NotFound<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(CollegeDepartment)));

            var result = await _collegeDepartmentService.DeleteAsync(collegeDepartment);
            return Success(result);
        }


        #endregion
    }
}

