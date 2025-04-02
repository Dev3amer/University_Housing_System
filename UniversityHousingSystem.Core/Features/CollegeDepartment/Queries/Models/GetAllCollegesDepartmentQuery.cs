using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetAllCollegesDepartmentQuery : IRequest<Response<List<GetAllCollegeDepartmentResponse>>>
    {
    }
}
