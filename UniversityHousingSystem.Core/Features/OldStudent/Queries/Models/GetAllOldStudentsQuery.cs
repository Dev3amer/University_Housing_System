﻿using MediatR;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.OldStudent.Queries.Models
{
    public class GetAllOldStudentsQuery : IRequest<Response<List<GetAllOldStudentsResponse>>>
    {
    }
}
