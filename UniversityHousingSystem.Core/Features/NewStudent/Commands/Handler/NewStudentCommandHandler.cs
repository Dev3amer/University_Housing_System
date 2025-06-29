﻿using MediatR;
using UniversityHousingSystem.Core.Features.NewStudent.Commands.Models;
using UniversityHousingSystem.Core.Features.NewStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.NewStudent.Commands.Handler
{
    public class NewStudentCommandHandler : ResponseHandler,
        IRequestHandler<CreateNewStudentCommand, Response<GetNewStudentByIdResponse>>,
        IRequestHandler<UpdateNewStudentCommand, Response<GetNewStudentByIdResponse>>,
        IRequestHandler<DeleteNewStudentWithDependanciesCommand, Response<bool>>
    {
        #region Fields
        private readonly INewStudentService _newStudentService;
        private readonly ICollegeService _collegeService;
        private readonly ICountryService _countryService;
        private readonly IVillageService _villageService;
        private readonly IHighSchoolService _highSchoolService;
        private readonly IQRService _qRService;
        private readonly IFileService _fileService;
        private readonly IRankingService _rankingService;
        private readonly ICollegeDepartmentService _collegeDepartmentService;
        private readonly IStudentRegistrationService _studentRegistrationService;
        private readonly IRegistrationPeriodService _registrationPeriodService;
        #endregion
        #region Constructor
        public NewStudentCommandHandler(INewStudentService newStudentService, ICollegeService collegeService, ICountryService countryService, IVillageService villageService, IHighSchoolService highSchoolService, IQRService qRService, IFileService fileService, IRankingService rankingService, ICollegeDepartmentService collegeDepartmentService, IStudentRegistrationService studentRegistrationService, IRegistrationPeriodService registrationPeriodService)
        {
            _newStudentService = newStudentService;
            _collegeService = collegeService;
            _countryService = countryService;
            _villageService = villageService;
            _highSchoolService = highSchoolService;
            _qRService = qRService;
            _fileService = fileService;
            _rankingService = rankingService;
            _collegeDepartmentService = collegeDepartmentService;
            _studentRegistrationService = studentRegistrationService;
            _registrationPeriodService = registrationPeriodService;
        }
        #endregion

        #region Handlers
        public async Task<Response<GetNewStudentByIdResponse>> Handle(CreateNewStudentCommand request, CancellationToken cancellationToken)
        {
            var collage = await _collegeService.GetAsync(request.CollageId);
            if (collage is null)
                return BadRequest<GetNewStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(College)));

            var country = await _countryService.GetAsync(request.CountryId);
            if (country is null)
                return BadRequest<GetNewStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.Country)));

            var village = await _villageService.GetAsync(request.VillageId);
            if (village is null)
                return BadRequest<GetNewStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.Village)));

            var highSchool = await _highSchoolService.GetAsync(request.HighSchoolId);
            if (highSchool is null)
                return BadRequest<GetNewStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(HighSchool)));

            var collegeDept = await _collegeDepartmentService.GetAsync(request.CollageDepartmentId);
            if (collegeDept is null)
                return BadRequest<GetNewStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.CollegeDepartment)));

            var registrationCode = await _studentRegistrationService.GetByCodeAsync(request.RegistrationCode);
            if (registrationCode is null || registrationCode.IsUsed || !registrationCode.IsPaid)
                return BadRequest<GetNewStudentByIdResponse>(string.Format(SharedResourcesKeys.Invalid, nameof(Data.Entities.StudentRegistrationCode)));

            var currentPeriod = await _registrationPeriodService.GetCurrentRegistrationPeriodAsync();
            if (currentPeriod == null || DateTime.Now < currentPeriod.From || DateTime.Now > currentPeriod.To || currentPeriod.IsClosed)
            {
                BadRequest<GetNewStudentByIdResponse>(string.Format(SharedResourcesKeys.RegistrationClosed));
            }

            var qrText = Guid.NewGuid().ToString();

            var studentDocuments = new List<Document>()
            {
                new Document(){DocumentType = EnDocumentType.NationalIdImage,
                                Path = await _fileService.SaveFileAsync(request.NationalIdImage,"StudentsIDs")},
                new Document(){DocumentType = EnDocumentType.GuardianNationalIdImage,
                                Path = await _fileService.SaveFileAsync(request.GuardianNationalIdImage,"GuardiansIDs")},
                new Document(){DocumentType = EnDocumentType.PersonalImage,
                                Path = await _fileService.SaveFileAsync(request.PersonalImage,"StudentsImages")},
                new Document(){DocumentType = EnDocumentType.waterBill,
                                Path = await _fileService.SaveFileAsync(request.WaterBill,"WaterBillsImages")},
                new Document(){DocumentType = EnDocumentType.ResidenceApplication,
                                Path = await _fileService.SaveFileAsync(request.ResidenceApplication,"Applications")},
            };

            var mappedNewStudent = new Data.Entities.NewStudent()
            {
                Student = new Student()
                {
                    FavRoom = request.FavRoomId,
                    FirstName = request.FirstName,
                    SecondName = request.SecondName,
                    ThirdName = request.ThirdName,
                    FourthName = request.FourthName,
                    NationalId = request.NationalId,
                    Phone = request.Phone,
                    BirthDate = request.BirthDate,
                    Gender = request.Gender,
                    Religion = request.Religion,
                    HasSpecialNeeds = request.HasSpecialNeeds,
                    AcademicStudentCode = request.AcademicStudentCode,
                    AcademicYear = request.AcademicYear,
                    Email = request.Email,
                    IsMarried = request.IsMarried,
                    QRText = qrText,
                    RegistrationPeriodId = currentPeriod.Id,
                    QRImagePath = _qRService.GenerateAndSaveQRCodeForStudent(qrText),
                    College = collage,
                    CollegeDepartment = collegeDept,
                    Country = country,
                    Village = village,
                    StudentRegistrationCode = registrationCode,
                    Application = new Application()
                    {
                        SubmitDate = DateTime.UtcNow,
                        AIValidationStatus = Data.Helpers.Enums.EnStatus.Pending,
                        FinalStatus = Data.Helpers.Enums.EnStatus.Pending,
                        AdminNotes = null,
                    },
                    Guardian = new Data.Entities.Guardian()
                    {
                        FirstName = request.GuardianFirstName,
                        SecondName = request.GuardianSecondName,
                        ThirdName = request.GuardianThirdName,
                        FourthName = request.GuardianFourthName,
                        Job = request.GuardianJob,
                        NationalId = request.GuardianNationalId,
                        Phone = request.GuardianPhone,
                        GuardianRelation = request.GuardianRelation
                    },
                    CurrentScore = 0.0,
                    Documents = studentDocuments
                },
                HighSchoolPercentage = request.HighSchoolPercentage,
                HighSchoolId = request.HighSchoolId
            };

            mappedNewStudent.Student.CurrentScore = await _rankingService.CalculateNewStudentScore(mappedNewStudent);
            var addedNewStudent = await _newStudentService.CreateAsync(mappedNewStudent);
            await _studentRegistrationService.ChangeCodeState(registrationCode);
            var mappedResponse = new GetNewStudentByIdResponse()

            {
                NewStudentId = addedNewStudent.NewStudentId,
                FirstName = addedNewStudent.Student.FirstName,
                SecondName = addedNewStudent.Student.SecondName,
                ThirdName = addedNewStudent.Student.ThirdName,
                FourthName = addedNewStudent.Student.FourthName,
                NationalId = addedNewStudent.Student.NationalId,
                Phone = addedNewStudent.Student.Phone,
                BirthDate = addedNewStudent.Student.BirthDate,
                Gender = addedNewStudent.Student.Gender,
                Religion = addedNewStudent.Student.Religion,
                HasSpecialNeeds = addedNewStudent.Student.HasSpecialNeeds,
                AcademicStudentCode = addedNewStudent.Student.AcademicStudentCode,
                AcademicYear = addedNewStudent.Student.AcademicYear,
                Email = addedNewStudent.Student.Email,
                IsMarried = addedNewStudent.Student.IsMarried,
                HighSchoolPercentage = addedNewStudent.HighSchoolPercentage,
                HighSchoolId = highSchool.HighSchoolId,
                HighSchoolName = highSchool.Name,
                CurrentScore = addedNewStudent.Student.CurrentScore,
                QRImagePath = addedNewStudent.Student.QRImagePath,
                GuardianId = addedNewStudent.Student.Guardian.GuardianId,
                GuardianFullName = $"{addedNewStudent.Student.Guardian.FirstName} " +
                $"{addedNewStudent.Student.Guardian.SecondName} {addedNewStudent.Student.Guardian.ThirdName}",
                GuardianPhone = addedNewStudent.Student.Guardian.Phone
            };

            return Created(mappedResponse, string.Format(SharedResourcesKeys.Created, nameof(Data.Entities.NewStudent)));
        }

        public async Task<Response<GetNewStudentByIdResponse>> Handle(UpdateNewStudentCommand request, CancellationToken cancellationToken)
        {
            var newStudentOldObj = await _newStudentService.GetAsync(request.NewStudentId);

            if (newStudentOldObj is null)
                return BadRequest<GetNewStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.NewStudent)));

            #region Mapping
            newStudentOldObj.Student.FavRoom = request.FavRoomId;
            newStudentOldObj.Student.FirstName = request.FirstName;
            newStudentOldObj.Student.SecondName = request.SecondName;
            newStudentOldObj.Student.ThirdName = request.ThirdName;
            newStudentOldObj.Student.FourthName = request.FourthName;
            newStudentOldObj.Student.NationalId = request.NationalId;
            newStudentOldObj.Student.Phone = request.Phone;
            newStudentOldObj.Student.BirthDate = request.BirthDate;
            newStudentOldObj.Student.Gender = request.Gender;
            newStudentOldObj.Student.Religion = request.Religion;
            newStudentOldObj.Student.HasSpecialNeeds = request.HasSpecialNeeds;
            newStudentOldObj.Student.AcademicStudentCode = request.AcademicStudentCode;
            newStudentOldObj.Student.AcademicYear = request.AcademicYear;
            newStudentOldObj.Student.Email = request.Email;
            newStudentOldObj.Student.IsMarried = request.IsMarried;
            newStudentOldObj.HighSchoolPercentage = request.HighSchoolPercentage;
            #endregion

            var updatedNewStudent = await _newStudentService.UpdateAsync(newStudentOldObj);
            var mappedResponse = new GetNewStudentByIdResponse()
            {
                NewStudentId = updatedNewStudent.NewStudentId,
                FirstName = updatedNewStudent.Student.FirstName,
                SecondName = updatedNewStudent.Student.SecondName,
                ThirdName = updatedNewStudent.Student.ThirdName,
                FourthName = updatedNewStudent.Student.FourthName,
                NationalId = updatedNewStudent.Student.NationalId,
                Phone = updatedNewStudent.Student.Phone,
                BirthDate = updatedNewStudent.Student.BirthDate,
                Gender = updatedNewStudent.Student.Gender,
                Religion = updatedNewStudent.Student.Religion,
                HasSpecialNeeds = updatedNewStudent.Student.HasSpecialNeeds,
                AcademicStudentCode = updatedNewStudent.Student.AcademicStudentCode,
                AcademicYear = updatedNewStudent.Student.AcademicYear,
                Email = updatedNewStudent.Student.Email,
                IsMarried = updatedNewStudent.Student.IsMarried,
                HighSchoolPercentage = updatedNewStudent.HighSchoolPercentage,
                HighSchoolId = updatedNewStudent.HighSchool.HighSchoolId,
                HighSchoolName = updatedNewStudent.HighSchool.Name,
                GuardianId = updatedNewStudent.Student.Guardian.GuardianId,
                GuardianFullName = $"{updatedNewStudent.Student.Guardian.FirstName} " +
                $"{updatedNewStudent.Student.Guardian.SecondName} {updatedNewStudent.Student.Guardian.ThirdName}",
                GuardianPhone = updatedNewStudent.Student.Guardian.Phone
            };

            return Success(mappedResponse);
        }

        public async Task<Response<bool>> Handle(DeleteNewStudentWithDependanciesCommand request, CancellationToken cancellationToken)
        {
            var searchedNewStudent = await _newStudentService.GetAsync(request.NewStudentId);

            if (searchedNewStudent is null)
                return BadRequest<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.NewStudent)));

            await _fileService.DeleteFileAsync(searchedNewStudent.Student.QRImagePath);

            foreach (var doc in searchedNewStudent.Student.Documents)
            {
                await _fileService.DeleteFileAsync(doc.Path);
            }

            var isDeleted = await _newStudentService.DeleteAsync(searchedNewStudent);
            return isDeleted ? Deleted<bool>(string.Format(SharedResourcesKeys.Deleted, nameof(Data.Entities.NewStudent))) : InternalServerError<bool>();
        }
        #endregion
    }
}
