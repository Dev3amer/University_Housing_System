using MediatR;
using UniversityHousingSystem.Core.Features.RegistrationPeriod.Commands.Models;
using UniversityHousingSystem.Core.Features.RegistrationPeriod.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.RegistrationPeriods.Commands.Handler
{
    public class RegistrationPeriodCommandHandler : ResponseHandler,
        IRequestHandler<CreateRegistrationPeriodCommand, Response<GetRegistrationPeriodByIdResponse>>,
        IRequestHandler<UpdateRegistrationPeriodCommand, Response<GetRegistrationPeriodByIdResponse>>,
        IRequestHandler<DeleteRegistrationPeriodCommand, Response<bool>>
    {
        #region Fields
        private readonly IRegistrationPeriodService _registrationPeriodService;
        #endregion
        #region Constructor
        public RegistrationPeriodCommandHandler(IRegistrationPeriodService registrationPeriodService)
        {
            _registrationPeriodService = registrationPeriodService;
        }
        #endregion
        public async Task<Response<GetRegistrationPeriodByIdResponse>> Handle(CreateRegistrationPeriodCommand request, CancellationToken cancellationToken)
        {

            var mappedPeriod = new Data.Entities.RegistrationPeriod()
            {
                From = request.From,
                To = request.To,
                IsClosed = request.IsClosed,
                RegistrationFees = request.RegistrationFees
            };

            var addedPeriod = await _registrationPeriodService.CreateAsync(mappedPeriod);
            var mappedResponse = new GetRegistrationPeriodByIdResponse()
            {
                Id = addedPeriod.Id,
                From = addedPeriod.From,
                IsClosed = addedPeriod.IsClosed,
                RegistrationFees = addedPeriod.RegistrationFees,
                To = addedPeriod.To
            };

            return Created(mappedResponse, string.Format(SharedResourcesKeys.Created, nameof(Data.Entities.RegistrationPeriod)));
        }

        public async Task<Response<GetRegistrationPeriodByIdResponse>> Handle(UpdateRegistrationPeriodCommand request, CancellationToken cancellationToken)
        {
            var oldPeriod = await _registrationPeriodService.GetAsync(request.Id);

            if (oldPeriod is null)
                return BadRequest<GetRegistrationPeriodByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.RegistrationPeriod)));

            oldPeriod.RegistrationFees = request.RegistrationFees;
            oldPeriod.From = request.From;
            oldPeriod.To = request.To;
            oldPeriod.IsClosed = request.IsClosed;

            var updatedEvent = await _registrationPeriodService.UpdateAsync(oldPeriod);
            var mappedResponse = new GetRegistrationPeriodByIdResponse()
            {
                Id = updatedEvent.Id,
                From = updatedEvent.From,
                To = updatedEvent.To,
                IsClosed = updatedEvent.IsClosed,
                RegistrationFees = updatedEvent.RegistrationFees
            };

            return Success(mappedResponse);
        }

        public async Task<Response<bool>> Handle(DeleteRegistrationPeriodCommand request, CancellationToken cancellationToken)
        {
            var searchedPeriod = await _registrationPeriodService.GetAsync(request.RegistrationPeriodId);

            if (searchedPeriod is null)
                return BadRequest<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.RegistrationPeriod)));

            var isDeleted = await _registrationPeriodService.DeleteAsync(searchedPeriod);
            return isDeleted ? Deleted<bool>(string.Format(SharedResourcesKeys.Deleted, nameof(Data.Entities.RegistrationPeriod))) : InternalServerError<bool>();
        }
    }
}
