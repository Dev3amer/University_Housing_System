using MediatR;
using UniversityHousingSystem.Core.Features.RegistrationPeriod.Queries.Results;
using UniversityHousingSystem.Core.Features.RegistrationPeriods.Queries.Models;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.RegistrationPeriods.Queries.Handler
{
    public class RegistrationPeriodQueryHandler : ResponseHandler,
        IRequestHandler<GetAllRegistrationPeriodsQuery, Response<List<GetAllRegistrationPeriodsResponse>>>,
        IRequestHandler<GetRegistrationPeriodByIdQuery, Response<GetRegistrationPeriodByIdResponse>>
    {
        #region Fields
        private readonly IRegistrationPeriodService _registrationPeriodService;
        #endregion
        #region Constructor
        public RegistrationPeriodQueryHandler(IRegistrationPeriodService registrationPeriodService)
        {
            _registrationPeriodService = registrationPeriodService;
        }
        #endregion
        #region handlers
        public async Task<Response<List<GetAllRegistrationPeriodsResponse>>> Handle(GetAllRegistrationPeriodsQuery request, CancellationToken cancellationToken)
        {
            var periodsList = await _registrationPeriodService.GetAllAsync();

            var mappedPeriodsList = periodsList.Select(e => new GetAllRegistrationPeriodsResponse()
            {
                Id = e.Id,
                From = e.From,
                IsClosed = e.IsClosed,
                RegistrationFees = e.RegistrationFees,
                To = e.To
            }).ToList();

            return Success(mappedPeriodsList);
        }

        public async Task<Response<GetRegistrationPeriodByIdResponse>> Handle(GetRegistrationPeriodByIdQuery request, CancellationToken cancellationToken)
        {
            var askedPeriod = await _registrationPeriodService.GetAsync(request.RegistrationPeriodId);

            if (askedPeriod is null)
                return NotFound<GetRegistrationPeriodByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(RegistrationPeriod)));

            var mappedPeriod = new GetRegistrationPeriodByIdResponse()
            {
                Id = askedPeriod.Id,
                From = askedPeriod.From,
                IsClosed = askedPeriod.IsClosed,
                RegistrationFees = askedPeriod.RegistrationFees,
                To = askedPeriod.To
            };

            return Success(mappedPeriod);
        }
        #endregion
    }
}
