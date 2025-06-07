using MediatR;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.RegistrationPeriods.Commands.Models
{
    public class CloseRegistrationPeriodCommand : IRequest<Response<bool>>
    {
        public int PeriodId { get; set; }
    }
}
