using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;
using UniversityHousingSystem.Service.Implementation;

namespace UniversityHousingSystem.Core.Features.Buildings.Queries.Handler
{
    public class ViolationTypeQueryHandler : ResponseHandler,
        IRequestHandler<GetAllViolationTypeQuery, Response<List<GetAllViolationsTypeResponse>>>,
        IRequestHandler<GetViolationTypeByIdQuery, Response<GetViolationTypeByIdResponse>>



    {
        #region Fields
        private readonly IViolationTypeService _violationTypeService;
        #endregion
        #region Constructor
        public ViolationTypeQueryHandler(IViolationTypeService violationTypeService)
        {
            _violationTypeService = violationTypeService;
        }
        #endregion
        #region handlers
        public async Task<Response<List<GetAllViolationsTypeResponse>>> Handle(GetAllViolationTypeQuery request, CancellationToken cancellationToken)
        {
            var ViolationstypesList = await _violationTypeService.GetAllAsync();

            var mappedViolationstypesList = ViolationstypesList.Select(b => new GetAllViolationsTypeResponse()
            {
                ViolationTypeId = b.ViolationTypeId,
                ViolationTypeName = b.Description,
            }).ToList();

            return Success(mappedViolationstypesList);
        }
        public async Task<Response<GetViolationTypeByIdResponse>> Handle(GetViolationTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var violationtype = await _violationTypeService.GetAsync(request.ViolationTypeId);

            if (violationtype is null)
                return NotFound<GetViolationTypeByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(ViolationType)));

            var mappedissuetype = new GetViolationTypeByIdResponse()
            {
                ViolationTypeId = violationtype.ViolationTypeId,
                ViolationTypeName = violationtype.Description,
                RequiredAmount = violationtype.RequiredAmount,
                ViolationLevel=violationtype.ViolationLevel.ToString()
            };

            return Success(mappedissuetype);
        }

      



        #endregion
    }
}
