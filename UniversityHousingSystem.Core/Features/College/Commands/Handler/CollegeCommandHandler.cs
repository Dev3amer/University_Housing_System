using MediatR;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Buildings.Commands.Handler
{
    public class CollegeCommandHandler : ResponseHandler,
      IRequestHandler<CreateCollegeCommand, Response<GetCollegeByIdResponse>>,
     IRequestHandler<UpdateCollegeCommand, Response<GetCollegeByIdResponse>>,
     IRequestHandler<DeleteCollegeCommand, Response<bool>>
    {
        #region Fields
        private readonly ICollegeService _collegeService;
        #endregion

        #region Constructor
        public CollegeCommandHandler(
            ICollegeService collegeService)
        {
            _collegeService = collegeService;

        }
        #endregion

        #region Handlers

        public async Task<Response<GetCollegeByIdResponse>> Handle(CreateCollegeCommand request, CancellationToken cancellationToken)
        {
            var college = new Data.Entities.College
            {
                Name = request.Name,
                //   Departments = request.Departments?.Select(d => new CollegeDepartment { Name = d }).ToList()
            };

            var createdCollege = await _collegeService.CreateAsync(college);

            var response = new GetCollegeByIdResponse
            {
                CollegeId = createdCollege.CollegeId,
                Name = createdCollege.Name,
                //  Departments = createdCollege.Departments?.Select(d => d.Name).ToList()
            };

            return Created(response, string.Format(SharedResourcesKeys.Created, nameof(College)));
        }




        // ********** Update Guardian **********
        public async Task<Response<GetCollegeByIdResponse>> Handle(UpdateCollegeCommand request, CancellationToken cancellationToken)
        {
            var college = await _collegeService.GetAsync(request.CollegeId);
            if (college == null)
                return NotFound<GetCollegeByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Guardian)));

            college.Name = request.Name;
            //  college.Departments = request.Departments.Select(d => new CollegeDepartment { Name = d }).ToList();


            var updatedCollege = await _collegeService.UpdateAsync(college);

            var response = new GetCollegeByIdResponse
            {
                Name = updatedCollege.Name,
                //  Departments = updatedCollege.Departments?.Select(d => d.Name).ToList()

            };

            return Success(response);
        }
        //delete
        public async Task<Response<bool>> Handle(DeleteCollegeCommand request, CancellationToken cancellationToken)
        {
            var college = await _collegeService.GetAsync(request.CollegeId);
            if (college == null)
                return NotFound<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(College)));

            var result = await _collegeService.DeleteAsync(college);
            return Success(result);
        }

        #endregion
    }
}

