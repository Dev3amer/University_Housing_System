﻿using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetCollegeByIdQuery : IRequest<Response<GetCollegeByIdResponse>>
    {
        public int CollegeId { get; set; }
        public GetCollegeByIdQuery(int collegeId) => CollegeId = collegeId;
    }
}
