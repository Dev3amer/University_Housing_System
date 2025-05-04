using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Core.Features.NewStudent.Queries.Models;
using UniversityHousingSystem.Core.Features.NewStudent.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.NewStudent.Queries.Handler
{
    public class NewStudentQueryHandler : ResponseHandler,
        IRequestHandler<GetAllNewStudentsQuery, Response<List<GetAllNewStudentsResponse>>>,
        IRequestHandler<GetNewStudentByIdQuery, Response<GetNewStudentByIdResponse>>,
        IRequestHandler<GetNewStudentsPaginatedListQuery, PaginatedList<GetNewStudentsPaginatedListResponse>>
    {
        #region Fields
        private readonly INewStudentService _newStudentService;
        #endregion

        #region Constructor
        public NewStudentQueryHandler(INewStudentService newStudentService)
        {
            _newStudentService = newStudentService;
        }
        #endregion

        #region Handlers
        async Task<Response<List<GetAllNewStudentsResponse>>> IRequestHandler<GetAllNewStudentsQuery, Response<List<GetAllNewStudentsResponse>>>.Handle(GetAllNewStudentsQuery request, CancellationToken cancellationToken)
        {
            var allNewStudents = await _newStudentService.GetAllQueryable(null, null).Select(ns => new GetAllNewStudentsResponse()
            {
                NewStudentId = ns.NewStudentId,
                FirstName = ns.Student.FirstName,
                SecondName = ns.Student.SecondName,
                ThirdName = ns.Student.ThirdName,
                FourthName = ns.Student.FourthName,
                NationalId = ns.Student.NationalId,
                Phone = ns.Student.Phone,
                Telephone = ns.Student.Telephone,
                BirthDate = ns.Student.BirthDate,
                Gender = ns.Student.Gender,
                Religion = ns.Student.Religion,
                PlaceOfBirth = ns.Student.PlaceOfBirth,
                HasSpecialNeeds = ns.Student.HasSpecialNeeds,
                AcademicStudentCode = ns.Student.AcademicStudentCode,
                AcademicYear = ns.Student.AcademicYear,
                Email = ns.Student.Email,
                IsMarried = ns.Student.IsMarried,
                AddressLine = ns.Student.AddressLine,
                HighSchoolPercentage = ns.HighSchoolPercentage,
                IsOutsideSchool = ns.IsOutsideSchool,
                HighSchoolId = ns.HighSchool.HighSchoolId,
                HighSchoolName = ns.HighSchool.Name,
                QRImagePath = ns.Student.QRImagePath,
                CurrentScore = ns.Student.CurrentScore
            }).ToListAsync();

            return Success(allNewStudents);
        }
        public async Task<Response<GetNewStudentByIdResponse>> Handle(GetNewStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var newStudent = await _newStudentService.GetAllQueryable(null, null).Select(ns => new GetNewStudentByIdResponse()
            {
                NewStudentId = ns.NewStudentId,
                FirstName = ns.Student.FirstName,
                SecondName = ns.Student.SecondName,
                ThirdName = ns.Student.ThirdName,
                FourthName = ns.Student.FourthName,
                NationalId = ns.Student.NationalId,
                Phone = ns.Student.Phone,
                Telephone = ns.Student.Telephone,
                BirthDate = ns.Student.BirthDate,
                Gender = ns.Student.Gender,
                Religion = ns.Student.Religion,
                PlaceOfBirth = ns.Student.PlaceOfBirth,
                HasSpecialNeeds = ns.Student.HasSpecialNeeds,
                AcademicStudentCode = ns.Student.AcademicStudentCode,
                AcademicYear = ns.Student.AcademicYear,
                Email = ns.Student.Email,
                IsMarried = ns.Student.IsMarried,
                AddressLine = ns.Student.AddressLine,
                HighSchoolPercentage = ns.HighSchoolPercentage,
                IsOutsideSchool = ns.IsOutsideSchool,
                HighSchoolId = ns.HighSchool.HighSchoolId,
                HighSchoolName = ns.HighSchool.Name,
                QRImagePath = ns.Student.QRImagePath,
                CurrentScore = ns.Student.CurrentScore
            }).FirstOrDefaultAsync(os => os.NewStudentId == request.NewStudentId);

            if (newStudent is null)
                return NotFound<GetNewStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(NewStudent)));

            return Success(newStudent);
        }

        public async Task<PaginatedList<GetNewStudentsPaginatedListResponse>> Handle(GetNewStudentsPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var oldStudentsListQueryable = _newStudentService.GetAllQueryable(request.Search, request.StudentOrdering);

            var paginatedList = await oldStudentsListQueryable.Select(ns => new GetNewStudentsPaginatedListResponse
            {
                NewStudentId = ns.NewStudentId,
                FirstName = ns.Student.FirstName,
                SecondName = ns.Student.SecondName,
                ThirdName = ns.Student.ThirdName,
                FourthName = ns.Student.FourthName,
                NationalId = ns.Student.NationalId,
                Phone = ns.Student.Phone,
                Telephone = ns.Student.Telephone,
                BirthDate = ns.Student.BirthDate,
                Gender = ns.Student.Gender,
                Religion = ns.Student.Religion,
                PlaceOfBirth = ns.Student.PlaceOfBirth,
                HasSpecialNeeds = ns.Student.HasSpecialNeeds,
                AcademicStudentCode = ns.Student.AcademicStudentCode,
                AcademicYear = ns.Student.AcademicYear,
                Email = ns.Student.Email,
                IsMarried = ns.Student.IsMarried,
                AddressLine = ns.Student.AddressLine,
                HighSchoolPercentage = ns.HighSchoolPercentage,
                IsOutsideSchool = ns.IsOutsideSchool,
                HighSchoolId = ns.HighSchool.HighSchoolId,
                HighSchoolName = ns.HighSchool.Name,
                QRImagePath = ns.Student.QRImagePath,
                CurrentScore = ns.Student.CurrentScore
            }).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }

        #endregion
    }
}
