using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.OldStudent.Commands.Models
{
    public class DeleteOldStudentCommand : IRequest<Response<bool>>
    {
        public int OldStudentId { get; set; }
    }
}
