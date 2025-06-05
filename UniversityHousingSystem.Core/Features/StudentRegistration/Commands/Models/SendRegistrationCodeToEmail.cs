using MediatR;
using UniversityHousingSystem.Core.Features.StudentRegistration.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.StudentRegistration.Commands.Models
{
    public class SendRegistrationCodeToEmail : IRequest<Response<StudentRegistrationCodeResult>>
    {
        public string Email { get; set; } = default!;
    }
}
