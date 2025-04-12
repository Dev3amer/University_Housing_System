using MediatR;
using UniversityHousingSystem.Core.Features.OldStudent.Commands.Models;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.OldStudent.Commands.Handler
{
    public class OldStudentCommandHandler : ResponseHandler,
        IRequestHandler<CreateOldStudentCommand, Response<GetOldStudentByIdResponse>>
    {
        #region Fields
        private readonly IOldStudentService _oldStudentService;
        private readonly ICollegeService _collegeService;
        private readonly ICountryService _countryService;
        private readonly IVillageService _villageService;

        #endregion
        #region Constructor
        public OldStudentCommandHandler(IOldStudentService oldStudentService, ICollegeService collegeService, ICountryService countryService, IVillageService villageService)
        {
            _oldStudentService = oldStudentService;
            _collegeService = collegeService;
            _countryService = countryService;
            _villageService = villageService;
        }
        #endregion
        #region Handlers
        public async Task<Response<GetOldStudentByIdResponse>> Handle(CreateOldStudentCommand request, CancellationToken cancellationToken)
        {
            var collage = await _collegeService.GetAsync(request.CollageId);
            if (collage is null)
                return BadRequest<GetOldStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(College)));

            var country = await _countryService.GetAsync(request.CountryId);
            if (country is null)
                return BadRequest<GetOldStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.Country)));

            var village = await _villageService.GetAsync(request.VillageId);
            if (village is null)
                return BadRequest<GetOldStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.Village)));

            var mappedOldStudent = new Data.Entities.OldStudent()
            {
                Student = new Data.Entities.Student()
                {
                    FirstName = request.FirstName,
                    SecondName = request.SecondName,
                    ThirdName = request.ThirdName,
                    FourthName = request.FourthName,
                    NationalId = request.NationalId,
                    Phone = request.Phone,
                    Telephone = request.Telephone,
                    BirthDate = request.BirthDate,
                    Gender = request.Gender,
                    Religion = request.Religion,
                    PlaceOfBirth = request.PlaceOfBirth,
                    HasSpecialNeeds = request.HasSpecialNeeds,
                    AcademicStudentCode = request.AcademicStudentCode,
                    AcademicYear = request.AcademicYear,
                    Email = request.Email,
                    IsMarried = request.IsMarried,
                    AddressLine = request.AddressLine,
                    StudentQR = request.StudentQR,
                    College = collage,
                    Country = country,
                    Village = village,
                    Application = new Application()
                    {
                        SubmitDate = DateTime.UtcNow,
                        AIValidationStatus = Data.Helpers.Enums.EnStatus.Pending,
                        FinalStatus = Data.Helpers.Enums.EnStatus.Pending,
                        AdminNotes = null,
                    },
                    Guardian = new Guardian()
                    {
                        FirstName = request.GuardianFirstName,
                        SecondName = request.GuardianSecondName,
                        ThirdName = request.GuardianThirdName,
                        FourthName = request.GuardianFourthName,
                        Job = request.GuardianJob,
                        NationalId = request.GuardianNationalId,
                        Phone = request.GuardianPhone,
                        GuardianRelation = request.GuardianRelation
                    }
                },
                PreviousYearGrade = request.PreviousYearGrade,
                GradePercentage = request.GradePercentage,
                PreviousYearHosting = request.PreviousYearHosting,
            };

            var addedOldStudent = await _oldStudentService.CreateAsync(mappedOldStudent);
            var mappedResponse = new GetOldStudentByIdResponse()
            {
                OldStudentId = addedOldStudent.OldStudentId,
                FirstName = addedOldStudent.Student.FirstName,
                SecondName = addedOldStudent.Student.SecondName,
                ThirdName = addedOldStudent.Student.ThirdName,
                FourthName = addedOldStudent.Student.FourthName,
                NationalId = addedOldStudent.Student.NationalId,
                Phone = addedOldStudent.Student.Phone,
                Telephone = addedOldStudent.Student.Telephone,
                BirthDate = addedOldStudent.Student.BirthDate,
                Gender = addedOldStudent.Student.Gender,
                Religion = addedOldStudent.Student.Religion,
                PlaceOfBirth = addedOldStudent.Student.PlaceOfBirth,
                HasSpecialNeeds = addedOldStudent.Student.HasSpecialNeeds,
                AcademicStudentCode = addedOldStudent.Student.AcademicStudentCode,
                AcademicYear = addedOldStudent.Student.AcademicYear,
                Email = addedOldStudent.Student.Email,
                IsMarried = addedOldStudent.Student.IsMarried,
                AddressLine = addedOldStudent.Student.AddressLine,
                StudentQR = addedOldStudent.Student.StudentQR,
                PreviousYearGrade = addedOldStudent.PreviousYearGrade,
                GradePercentage = addedOldStudent.GradePercentage,
                PreviousYearHosting = addedOldStudent.PreviousYearHosting
            };

            return Created(mappedResponse, string.Format(SharedResourcesKeys.Created, nameof(Data.Entities.OldStudent)));
        }
        #endregion
    }
}
