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
    public class IssueTypeQueryHandler : ResponseHandler,
        IRequestHandler<GetAllIssueTypeQuery, Response<List<GetAllIssueTypeResponse>>>,
        IRequestHandler<GetIssueTypeByIdQuery, Response<GetIssueTypeByIdResponse>>



    {
        #region Fields
        private readonly IIssueTypeService _issueTypeService;
        #endregion
        #region Constructor
        public IssueTypeQueryHandler(IIssueTypeService issueTypeService)
        {
            _issueTypeService = issueTypeService;
        }
        #endregion
        #region handlers
        public async Task<Response<List<GetAllIssueTypeResponse>>> Handle(GetAllIssueTypeQuery request, CancellationToken cancellationToken)
        {
            var IssuestypesList = await _issueTypeService.GetAllAsync();

            var mappedIssuestypesList = IssuestypesList.Select(b => new GetAllIssueTypeResponse()
            {
                IssueTypeId = b.IssueTypeId,
                TypeName = b.TypeName,
            }).ToList();

            return Success(mappedIssuestypesList);
        }
        public async Task<Response<GetIssueTypeByIdResponse>> Handle(GetIssueTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var issuetype = await _issueTypeService.GetAsync(request.IssueTypeId);

            if (issuetype is null)
                return NotFound<GetIssueTypeByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(IssueType)));

            var mappedissuetype = new GetIssueTypeByIdResponse()
            {
                IssueTypeId = issuetype.IssueTypeId,
                TypeName = issuetype.TypeName,
               
            };

            return Success(mappedissuetype);
        }

      



        #endregion
    }
}
