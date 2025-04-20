using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.NewStudent.Commands.Models
{
    public class DeleteNewStudentCommand : IRequest<Response<bool>>
    {
        public int NewStudentId { get; set; }
    }
}
