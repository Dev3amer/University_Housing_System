using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Buildings.Queries.Handler
{
    public class CollegeDepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetAllCollegesDepartmentQuery, Response<List<GetAllCollegeDepartmentResponse>>>,
        IRequestHandler<GetCollegeDepartmentByIdQuery, Response<GetCollegeDepartmentByIdResponse>>



    {
        #region Fields
        private readonly ICollegeDepartmentService _collegeDepartmentService;
        #endregion
        #region Constructor
        public CollegeDepartmentQueryHandler(ICollegeDepartmentService collegeDepartmentService)
        {
            _collegeDepartmentService = collegeDepartmentService;
        }
        #endregion
        #region handlers
        public async Task<Response<List<GetAllCollegeDepartmentResponse>>> Handle(GetAllCollegesDepartmentQuery request, CancellationToken cancellationToken)
        {
            var collegeList = await _collegeDepartmentService.GetAllAsync();

            var mappedCollegesDepartmentList = collegeList.Select(c => new GetAllCollegeDepartmentResponse()
            {
                CollegeDepartmentId = (byte)c.CollegeDepartmentId,
                Name = c.Name,
                CollegeId = c.CollegeId,
            }).ToList();

            return Success(mappedCollegesDepartmentList);
        }
        public async Task<Response<GetCollegeDepartmentByIdResponse>> Handle(GetCollegeDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var college = await _collegeDepartmentService.GetAsync(request.CollegeDepartmentId);

            if (college is null)
            {
                return NotFound<GetCollegeDepartmentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Building)));

            }

            var mappedCollege = new GetCollegeDepartmentByIdResponse
            {
                CollegeDepartmentId = (byte)college.CollegeDepartmentId,
                Name = college.Name,
                CollegeId = college.CollegeId,
              //  Students = college.Students?.Select(s => s.FirstName).ToList()
            };

            return Success(mappedCollege);
        }





        #endregion
    }
}
