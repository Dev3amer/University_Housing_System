using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Buildings.Queries.Handler
{
    public class ViolationQueryHandler : ResponseHandler,
        IRequestHandler<GetAllViolationsQuery, Response<List<GetAllViolationsResponse>>>,
        IRequestHandler<GetViolationByIdQuery, Response<GetViolationByIdResponse>>


        //cd
    {
        #region Fields
        private readonly IViolationService _violationService;
        #endregion
        #region Constructor
        public ViolationQueryHandler(IViolationService violationService)
        {
            _violationService = violationService;
        }
        #endregion
        #region handlers
        public async Task<Response<List<GetAllViolationsResponse>>> Handle(GetAllViolationsQuery request, CancellationToken cancellationToken)
        {
            var violationList = await _violationService.GetAllAsync();

            var mappedViolationList = violationList.Select(c => new GetAllViolationsResponse()
            {
                ViolationId = c.ViolationId,
                ViolationTypeId = c.ViolationTypeId,
                ViolationDate = c.ViolationDate,

            }).ToList();

            return Success(mappedViolationList);
        }
        public async Task<Response<GetViolationByIdResponse>> Handle(GetViolationByIdQuery request, CancellationToken cancellationToken)
        {
            var violationType = await _violationService.GetAsync(request.ViolationID);

            if (violationType is null)
            {
                return NotFound<GetViolationByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Violation)));

            }

            var mappedViolation = new GetViolationByIdResponse
            {
                ViolationId = violationType.ViolationId,
                ViolationTypeId = violationType.ViolationTypeId,
                StudentHistoryId = violationType.StudentHistoryId,
                ViolationDate = violationType.ViolationDate,
            };

            return Success(mappedViolation);
        }





        #endregion
    }
}
