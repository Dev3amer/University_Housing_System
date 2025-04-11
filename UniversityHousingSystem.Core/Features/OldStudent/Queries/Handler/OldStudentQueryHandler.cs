﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Models;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.OldStudent.Queries.Handler
{
    public class OldStudentQueryHandler : ResponseHandler,
        IRequestHandler<GetAllOldStudentsQuery, Response<List<GetAllOldStudentsResponse>>>,
        IRequestHandler<GetOldStudentByIdQuery, Response<GetOldStudentByIdResponse>>
    {
        #region Fields
        private readonly IOldStudentService _oldStudentService;
        #endregion

        #region Constructor
        public OldStudentQueryHandler(IOldStudentService oldStudentService)
        {
            _oldStudentService = oldStudentService;
        }
        #endregion

        #region Handlers
        async Task<Response<List<GetAllOldStudentsResponse>>> IRequestHandler<GetAllOldStudentsQuery, Response<List<GetAllOldStudentsResponse>>>.Handle(GetAllOldStudentsQuery request, CancellationToken cancellationToken)
        {
            var allOldStudents = await _oldStudentService.GetAllQueryable(null, null).Select(os => new GetAllOldStudentsResponse()
            {
                OldStudentId = os.OldStudentId,
                FirstName = os.Student.FirstName,
                SecondName = os.Student.SecondName,
                ThirdName = os.Student.ThirdName,
                FourthName = os.Student.FourthName,
                NationalId = os.Student.NationalId,
                Phone = os.Student.Phone,
                Telephone = os.Student.Telephone,
                BirthDate = os.Student.BirthDate,
                Gender = os.Student.Gender,
                Religion = os.Student.Religion,
                PlaceOfBirth = os.Student.PlaceOfBirth,
                HasSpecialNeeds = os.Student.HasSpecialNeeds,
                AcademicStudentCode = os.Student.AcademicStudentCode,
                AcademicYear = os.Student.AcademicYear,
                Email = os.Student.Email,
                IsMarried = os.Student.IsMarried,
                AddressLine = os.Student.AddressLine,
                StudentQR = os.Student.StudentQR,
                PreviousYearGrade = os.PreviousYearGrade,
                GradePercentage = os.GradePercentage,
                PreviousYearHosting = os.PreviousYearHosting
            }).ToListAsync();

            return Success(allOldStudents);
        }
        public async Task<Response<GetOldStudentByIdResponse>> Handle(GetOldStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var oldStudent = await _oldStudentService.GetAllQueryable(null, null).Select(os => new GetOldStudentByIdResponse()
            {
                OldStudentId = os.OldStudentId,
                FirstName = os.Student.FirstName,
                SecondName = os.Student.SecondName,
                ThirdName = os.Student.ThirdName,
                FourthName = os.Student.FourthName,
                NationalId = os.Student.NationalId,
                Phone = os.Student.Phone,
                Telephone = os.Student.Telephone,
                BirthDate = os.Student.BirthDate,
                Gender = os.Student.Gender,
                Religion = os.Student.Religion,
                PlaceOfBirth = os.Student.PlaceOfBirth,
                HasSpecialNeeds = os.Student.HasSpecialNeeds,
                AcademicStudentCode = os.Student.AcademicStudentCode,
                AcademicYear = os.Student.AcademicYear,
                Email = os.Student.Email,
                IsMarried = os.Student.IsMarried,
                AddressLine = os.Student.AddressLine,
                StudentQR = os.Student.StudentQR,
                PreviousYearGrade = os.PreviousYearGrade,
                GradePercentage = os.GradePercentage,
                PreviousYearHosting = os.PreviousYearHosting
            }).FirstOrDefaultAsync(os => os.OldStudentId == request.OldStudentId);

            if (oldStudent is null)
                return NotFound<GetOldStudentByIdResponse>(String.Format(SharedResourcesKeys.NotFound, nameof(OldStudent)));

            return Success(oldStudent);
        }
        #endregion
    }
}
