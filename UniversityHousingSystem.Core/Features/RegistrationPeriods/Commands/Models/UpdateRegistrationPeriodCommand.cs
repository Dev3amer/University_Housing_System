using MediatR;
using UniversityHousingSystem.Core.Features.RegistrationPeriod.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.RegistrationPeriod.Commands.Models
{
    public class UpdateRegistrationPeriodCommand : IRequest<Response<GetRegistrationPeriodByIdResponse>>
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsClosed { get; set; }
        public decimal RegistrationFees { get; set; }
    }
}
