using MediatR;
using UniversityHousingSystem.Core.Features.HighSchools.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.HighSchools.Queries.Models
{
    public class GetAllHighSchoolsQuery : IRequest<Response<List<GetAllHighSchoolsResponse>>>
    {
    }
}
