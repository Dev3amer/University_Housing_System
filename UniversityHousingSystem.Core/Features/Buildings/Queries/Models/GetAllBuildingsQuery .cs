﻿using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetAllBuildingsQuery : IRequest<Response<List<GetAllBuildingResponse>>>
    {
    }
}
