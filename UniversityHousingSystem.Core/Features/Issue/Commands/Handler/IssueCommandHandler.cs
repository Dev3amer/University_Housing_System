using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Handler
{
    public class IssueCommandHandler : ResponseHandler,
        IRequestHandler<CreateIssueCommand, Response<GetIssueByIdResponse>>,
        IRequestHandler<UpdateIssueCommand, Response<GetIssueByIdResponse>>,
        IRequestHandler<DeleteIssueCommand, Response<bool>> // ✅ Fixed Typo
    {
        private readonly IIssueService _issueService;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IssueCommandHandler(IIssueService issueService, ICurrentUserService currentUserService, UserManager<ApplicationUser> userManager)
        {
            _issueService = issueService;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }

        public async Task<Response<GetIssueByIdResponse>> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var currentStudent = _userManager.Users
                .Where(u => u.Id == _currentUserService.GetUserId())
                .Select(u => u.Student)
                .FirstOrDefault();

            if (currentStudent is null)
                return Unauthorized<GetIssueByIdResponse>(SharedResourcesKeys.UnAuthorized);

            var issue = new Issue
            {
                Description = request.Description,
                Student = currentStudent,
                IssueTypeId = request.IssueTypeId
            };

            var createdIssue = await _issueService.CreateAsync(issue);

            // Prepare the response
            var response = new GetIssueByIdResponse
            {
                Description = createdIssue.Description,
                StudentId = createdIssue.StudentId,
                StudentName = $"{createdIssue.Student.FirstName} {createdIssue.Student.SecondName} {createdIssue.Student.ThirdName} {createdIssue.Student.FourthName}",  // 🔥 Concatenated full name
                IssueID = createdIssue.IssueId,
                CreatedDate = createdIssue.CreatedDate,
                IssuTypeID = createdIssue.IssueTypeId,
                IssueTypeName = createdIssue.IssueType.TypeName
            };

            return Success(response);
        }

        public async Task<Response<GetIssueByIdResponse>> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = await _issueService.GetAsync(request.IssueId);
            if (issue == null)
                return NotFound<GetIssueByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Issue)));

            //   issue.Description = request.Description;
            issue.ResponseDate = request.ResponseDate;
            issue.Response = request.Response;
            issue.IssueTypeId = request.IssueTypeId;
            issue.StudentId = request.StudentId;
            issue.EmployeeId = request.EmployeeId;

            var updatedIssue = await _issueService.UpdateAsync(issue);

            var response = new GetIssueByIdResponse
            {
                IssueID = updatedIssue.IssueId,
                Description = updatedIssue.Description,
                CreatedDate = updatedIssue.CreatedDate,
                ResponseDate = updatedIssue.ResponseDate,
                Response = updatedIssue.Response,
                IssuTypeID = updatedIssue.IssueTypeId,
                StudentId = updatedIssue.StudentId,
                EmployeeId = updatedIssue.EmployeeId
            };

            return Success(response);
        }
        public async Task<Response<bool>> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            // Explicitly cast CollegeDepartmentId to byte
            var issue = await _issueService.GetAsync(request.IssueId);

            if (issue == null)
                return NotFound<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Issue)));

            var result = await _issueService.DeleteAsync(issue);
            return Success(result);
        }
    }
}



