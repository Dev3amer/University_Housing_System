using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.CollegeDepartment.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;
using UniversityHousingSystem.Service.Implementation;

namespace UniversityHousingSystem.Core.Features.Buildings.Commands.Handler
{
    public class IssueTypeCommandHandler : ResponseHandler,
      IRequestHandler<CreateIssueTypeCommand, Response<GetIssueTypeByIdResponse>>,
     IRequestHandler<UpdateIssueTypeCommand, Response<GetIssueTypeByIdResponse>>,
     IRequestHandler<DeleteIssueTypeCommand, Response<bool>>
    {
        #region Fields
        private readonly IIssueTypeService _iIssueTypeService;
        #endregion

        #region Constructor
        public IssueTypeCommandHandler(
            IIssueTypeService iIssueTypeService)
        {
            _iIssueTypeService = iIssueTypeService;
        
        }
        #endregion

        #region Handlers
        public async Task<Response<GetIssueTypeByIdResponse>> Handle(CreateIssueTypeCommand request, CancellationToken cancellationToken)
        {

            // Create the new IssueType object
            var issueType = new IssueType
            {
                TypeName = request.TypeName
            };

            // Call the service to create the IssueType
            var createdissueType = await _iIssueTypeService.CreateAsync(issueType);

            // Prepare the response
            var response = new GetIssueTypeByIdResponse
            {
                IssueTypeId = createdissueType.IssueTypeId,
                TypeName = createdissueType.TypeName,
            };

            return Success(response);
        }
        public async Task<Response<GetIssueTypeByIdResponse>> Handle(UpdateIssueTypeCommand request, CancellationToken cancellationToken)
        {
            var issueType = await _iIssueTypeService.GetAsync(request.IssueTypeId);
            if (issueType == null)
                return NotFound<GetIssueTypeByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(IssueType)));

            issueType.TypeName = request.TypeName;
          

            var updatedIssueType = await _iIssueTypeService.UpdateAsync(issueType);

            var response = new GetIssueTypeByIdResponse
            {
                IssueTypeId = updatedIssueType.IssueTypeId,
                TypeName = updatedIssueType.TypeName,
            };

            return Success(response);
        }
        public async Task<Response<bool>> Handle(DeleteIssueTypeCommand request, CancellationToken cancellationToken)
        {
            // Explicitly cast CollegeDepartmentId to byte
            var issueType = await _iIssueTypeService.GetAsync(request.IssueTypeId);

            if (issueType == null)
                return NotFound<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(IssueType)));

            var result = await _iIssueTypeService.DeleteAsync(issueType);
            return Success(result);
        }


        #endregion
    }
}

