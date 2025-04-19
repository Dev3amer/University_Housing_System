using MediatR;
using UniversityHousingSystem.Core.Features.NewStudent.Queries.Results;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.NewStudent.Queries.Models
{
    public class GetAllNewStudentsQuery : IRequest<Response<List<GetAllNewStudentsResponse>>>
    {
    }
}
