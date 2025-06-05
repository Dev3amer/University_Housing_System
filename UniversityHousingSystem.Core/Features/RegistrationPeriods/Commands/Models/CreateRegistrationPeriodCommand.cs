using MediatR;
using UniversityHousingSystem.Core.Features.RegistrationPeriod.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.RegistrationPeriod.Commands.Models
{
    public class CreateRegistrationPeriodCommand : IRequest<Response<GetRegistrationPeriodByIdResponse>>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsClosed { get; set; }
        public decimal RegistrationFees { get; set; }
    }
}
