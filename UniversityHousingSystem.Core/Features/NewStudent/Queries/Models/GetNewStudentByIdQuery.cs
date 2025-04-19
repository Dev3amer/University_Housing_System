using MediatR;
using UniversityHousingSystem.Core.Features.NewStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.NewStudent.Queries.Models
{
    public class GetNewStudentByIdQuery : IRequest<Response<GetNewStudentByIdResponse>>
    {
        public int NewStudentId { get; set; }
    }
}
