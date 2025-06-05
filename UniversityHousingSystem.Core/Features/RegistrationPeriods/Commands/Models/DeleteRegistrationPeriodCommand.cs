using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.RegistrationPeriod.Commands.Models
{
    public class DeleteRegistrationPeriodCommand : IRequest<Response<bool>>
    {
        public int RegistrationPeriodId { get; set; }
    }
}
