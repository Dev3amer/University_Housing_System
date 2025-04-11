using MediatR;
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
            var allOldStudents = await _oldStudentService.GetAllAsync();

            var mappedOldStudentsList = allOldStudents.Select(os => new GetAllOldStudentsResponse()
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
                PreviousYearHosting = os.PreviousYearHosting,
            }).ToList();

            return Success(mappedOldStudentsList);
        }
        public async Task<Response<GetOldStudentByIdResponse>> Handle(GetOldStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var oldStudent = await _oldStudentService.GetAsync(request.OldStudentId);

            if (oldStudent is null)
                return NotFound<GetOldStudentByIdResponse>(String.Format(SharedResourcesKeys.NotFound, nameof(OldStudent)));

            var mappedOldStudent = new GetOldStudentByIdResponse()
            {
                OldStudentId = oldStudent.OldStudentId,
                FirstName = oldStudent.Student.FirstName,
                SecondName = oldStudent.Student.SecondName,
                ThirdName = oldStudent.Student.ThirdName,
                FourthName = oldStudent.Student.FourthName,
                NationalId = oldStudent.Student.NationalId,
                Phone = oldStudent.Student.Phone,
                Telephone = oldStudent.Student.Telephone,
                BirthDate = oldStudent.Student.BirthDate,
                Gender = oldStudent.Student.Gender,
                Religion = oldStudent.Student.Religion,
                PlaceOfBirth = oldStudent.Student.PlaceOfBirth,
                HasSpecialNeeds = oldStudent.Student.HasSpecialNeeds,
                AcademicStudentCode = oldStudent.Student.AcademicStudentCode,
                AcademicYear = oldStudent.Student.AcademicYear,
                Email = oldStudent.Student.Email,
                IsMarried = oldStudent.Student.IsMarried,
                AddressLine = oldStudent.Student.AddressLine,
                StudentQR = oldStudent.Student.StudentQR,
                PreviousYearGrade = oldStudent.PreviousYearGrade,
                GradePercentage = oldStudent.GradePercentage,
                PreviousYearHosting = oldStudent.PreviousYearHosting,
            };

            return Success(mappedOldStudent);
        }
        #endregion
    }
}
