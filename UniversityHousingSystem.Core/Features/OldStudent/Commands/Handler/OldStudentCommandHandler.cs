﻿using MediatR;
using System.Diagnostics.Metrics;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Features.OldStudent.Commands.Models;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.OldStudent.Commands.Handler
{
    public class OldStudentCommandHandler : ResponseHandler,
        IRequestHandler<CreateOldStudentCommand, Response<GetOldStudentByIdResponse>>,
        IRequestHandler<UpdateOldStudentCommand, Response<GetOldStudentByIdResponse>>,
        IRequestHandler<DeleteOldStudentCommand, Response<bool>>
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

        public async Task<Response<GetOldStudentByIdResponse>> Handle(UpdateOldStudentCommand request, CancellationToken cancellationToken)
        {
            var oldStudentOldObj = await _oldStudentService.GetAsync(request.OldStudentId);

            if (oldStudentOldObj is null)
                return BadRequest<GetOldStudentByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.OldStudent)));

            #region Mapping
            oldStudentOldObj.Student.FirstName = request.FirstName;
            oldStudentOldObj.Student.SecondName = request.SecondName;
            oldStudentOldObj.Student.ThirdName = request.ThirdName;
            oldStudentOldObj.Student.FourthName = request.FourthName;
            oldStudentOldObj.Student.NationalId = request.NationalId;
            oldStudentOldObj.Student.Phone = request.Phone;
            oldStudentOldObj.Student.Telephone = request.Telephone;
            oldStudentOldObj.Student.BirthDate = request.BirthDate;
            oldStudentOldObj.Student.Gender = request.Gender;
            oldStudentOldObj.Student.Religion = request.Religion;
            oldStudentOldObj.Student.PlaceOfBirth = request.PlaceOfBirth;
            oldStudentOldObj.Student.HasSpecialNeeds = request.HasSpecialNeeds;
            oldStudentOldObj.Student.AcademicStudentCode = request.AcademicStudentCode;
            oldStudentOldObj.Student.AcademicYear = request.AcademicYear;
            oldStudentOldObj.Student.Email = request.Email;
            oldStudentOldObj.Student.IsMarried = request.IsMarried;
            oldStudentOldObj.Student.AddressLine = request.AddressLine;
            oldStudentOldObj.Student.StudentQR = request.StudentQR;
            oldStudentOldObj.PreviousYearGrade = request.PreviousYearGrade;
            oldStudentOldObj.GradePercentage = request.GradePercentage;
            oldStudentOldObj.PreviousYearHosting = request.PreviousYearHosting;
            #endregion

            var updatedOldStudent = await _oldStudentService.UpdateAsync(oldStudentOldObj);
            var mappedResponse = new GetOldStudentByIdResponse()
            {
                OldStudentId = updatedOldStudent.OldStudentId,
                FirstName = updatedOldStudent.Student.FirstName,
                SecondName = updatedOldStudent.Student.SecondName,
                ThirdName = updatedOldStudent.Student.ThirdName,
                FourthName = updatedOldStudent.Student.FourthName,
                NationalId = updatedOldStudent.Student.NationalId,
                Phone = updatedOldStudent.Student.Phone,
                Telephone = updatedOldStudent.Student.Telephone,
                BirthDate = updatedOldStudent.Student.BirthDate,
                Gender = updatedOldStudent.Student.Gender,
                Religion = updatedOldStudent.Student.Religion,
                PlaceOfBirth = updatedOldStudent.Student.PlaceOfBirth,
                HasSpecialNeeds = updatedOldStudent.Student.HasSpecialNeeds,
                AcademicStudentCode = updatedOldStudent.Student.AcademicStudentCode,
                AcademicYear = updatedOldStudent.Student.AcademicYear,
                Email = updatedOldStudent.Student.Email,
                IsMarried = updatedOldStudent.Student.IsMarried,
                AddressLine = updatedOldStudent.Student.AddressLine,
                StudentQR = updatedOldStudent.Student.StudentQR,
                PreviousYearGrade = updatedOldStudent.PreviousYearGrade,
                GradePercentage = updatedOldStudent.GradePercentage,
                PreviousYearHosting = updatedOldStudent.PreviousYearHosting
            };

            return Success(mappedResponse);
        }

        public async Task<Response<bool>> Handle(DeleteOldStudentCommand request, CancellationToken cancellationToken)
        {
            var searchedOldStudent = await _oldStudentService.GetAsync(request.OldStudentId);

            if (searchedOldStudent is null)
                return BadRequest<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.OldStudent)));

            var isDeleted = await _oldStudentService.DeleteAsync(searchedOldStudent);
            return isDeleted ? Deleted<bool>(string.Format(SharedResourcesKeys.Deleted, nameof(Data.Entities.OldStudent))) : InternalServerError<bool>();
        }
        #endregion
    }
}
