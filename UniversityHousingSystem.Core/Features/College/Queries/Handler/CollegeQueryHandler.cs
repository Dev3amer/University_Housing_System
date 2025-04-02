﻿using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Buildings.Queries.Handler
{
    public class CollegeQueryHandler : ResponseHandler,
        IRequestHandler<GetAllCollegesQuery, Response<List<GetAllCollegeResponse>>>,
        IRequestHandler<GetCollegeByIdQuery, Response<GetCollegeByIdResponse>>



    {
        #region Fields
        private readonly ICollegeService _collegeService;
        #endregion
        #region Constructor
        public CollegeQueryHandler(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }
        #endregion
        #region handlers
        public async Task<Response<List<GetAllCollegeResponse>>> Handle(GetAllCollegesQuery request, CancellationToken cancellationToken)
        {
            var collegeList = await _collegeService.GetAllAsync();

            var mappedCollegesList = collegeList.Select(c => new GetAllCollegeResponse()
            {
                CollegeId = c.CollegeId,
                Name = c.Name,
            }).ToList();

            return Success(mappedCollegesList);
        }
        public async Task<Response<GetCollegeByIdResponse>> Handle(GetCollegeByIdQuery request, CancellationToken cancellationToken)
        {
            var college = await _collegeService.GetAsync(request.CollegeId);

            if (college is null)
            {
                return NotFound<GetCollegeByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Building)));

            }

            var mappedCollege = new GetCollegeByIdResponse
            {
                CollegeId = college.CollegeId,
                Name = college.Name,
                Departments = college.Departments?.Select(d => d.Name).ToList(),
                Students = college.Students?.Select(s => s.FirstName).ToList()
            };

            return Success(mappedCollege);
        }





        #endregion
    }
}
