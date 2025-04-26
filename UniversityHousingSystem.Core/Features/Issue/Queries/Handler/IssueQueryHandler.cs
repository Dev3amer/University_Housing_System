using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Rooms.Queries.Handler
{
    public class IssueQueryHandler : ResponseHandler,
        IRequestHandler<GetAllIssuesQuery, Response<List<GetAllIssuesResponse>>>,
        IRequestHandler<GetIssueByIdQuery, Response<GetIssueByIdResponse>>


    {
        private readonly IIssueService _iIssueService;

        public IssueQueryHandler(IIssueService iIssueService) : base() // Ensure base constructor is called
        {
            _iIssueService = iIssueService;
        }

        public async Task<Response<List<GetAllIssuesResponse>>> Handle(GetAllIssuesQuery request, CancellationToken cancellationToken)
        {
            var issues = await _iIssueService.GetAllAsync();

            var response = issues.Select(issue => new GetAllIssuesResponse
            {
                IssueID = issue.IssueId,
                Description = issue.Description,
                CreatedDate = issue.CreatedDate,

                StudentName = $"{issue.Student?.FirstName ?? ""} {issue.Student?.SecondName ?? ""}".Trim(),
                EmployeeName = issue.Employee != null
                    ? $"{issue.Employee.FirstName} {issue.Employee.SecondName}".Trim()
                    : null,

                IssueTypeName = issue.IssueType?.TypeName ?? string.Empty,
                Response = issue.Response
            }).ToList();

            return Success(response);
        }


        public async Task<Response<GetIssueByIdResponse>> Handle(GetIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var issue = await _iIssueService.GetAsync(request.Id);

            if (issue == null)
                return NotFound<GetIssueByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Issue)));

            var response = new GetIssueByIdResponse
            {
                IssueID = issue.IssueId,
                Description = issue.Description,
                CreatedDate = issue.CreatedDate,
                ResponseDate = issue.ResponseDate,
                Response = issue.Response,

                IssuTypeID = issue.IssueTypeId,
                IssueTypeName = issue.IssueType.TypeName,  // 🆕 Get IssueType name

                StudentId = issue.StudentId,
                StudentName = $"{issue.Student.FirstName} {issue.Student.SecondName} {issue.Student.ThirdName} {issue.Student.FourthName}",  // 🔥 Concatenated full name

                EmployeeId = issue.EmployeeId,
                EmployeeName = issue.Employee != null ? $"{issue.Employee.FirstName} {issue.Employee.SecondName} {issue.Employee.ThirdName} {issue.Employee.FourthName}  " : null
            };

            return Success(response);  // FIXED
        }
        }
    }






