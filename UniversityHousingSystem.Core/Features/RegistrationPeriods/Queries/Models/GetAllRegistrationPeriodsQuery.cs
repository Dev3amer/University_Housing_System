using MediatR;
using UniversityHousingSystem.Core.Features.RegistrationPeriod.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.RegistrationPeriods.Queries.Models
{
    public class GetAllRegistrationPeriodsQuery : IRequest<Response<List<GetAllRegistrationPeriodsResponse>>>
    {

    }
}
