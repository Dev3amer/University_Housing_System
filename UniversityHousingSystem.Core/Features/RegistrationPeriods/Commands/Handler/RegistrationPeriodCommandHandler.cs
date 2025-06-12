using MediatR;
using UniversityHousingSystem.Core.Features.RegistrationPeriod.Commands.Models;
using UniversityHousingSystem.Core.Features.RegistrationPeriod.Queries.Results;
using UniversityHousingSystem.Core.Features.RegistrationPeriods.Commands.Models;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;
using UniversityHousingSystem.Service.Abstractions.Helpers;

namespace UniversityHousingSystem.Core.Features.RegistrationPeriods.Commands.Handler
{
    public class RegistrationPeriodCommandHandler : ResponseHandler,
        IRequestHandler<CreateRegistrationPeriodCommand, Response<GetRegistrationPeriodByIdResponse>>,
        IRequestHandler<UpdateRegistrationPeriodCommand, Response<GetRegistrationPeriodByIdResponse>>,
        IRequestHandler<DeleteRegistrationPeriodCommand, Response<bool>>,
        IRequestHandler<CloseRegistrationPeriodCommand, Response<bool>>


    {
        #region Fields
        private readonly IRegistrationPeriodService _registrationPeriodService;
        private readonly IStudentService _studentService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly IPasswordGeneratorService _passwordGeneratorService;
        private readonly IBuildingService _buildingService;
        private readonly IStudentHousingService _studentHousingService;
        private readonly IRoomService _roomService;
        #endregion
        #region Constructor
        public RegistrationPeriodCommandHandler(IRegistrationPeriodService registrationPeriodService, IStudentService studentService, IEmailService emailService, IUserService userService, IPasswordGeneratorService passwordGeneratorService, IBuildingService buildingService, IStudentHousingService studentHousingService, IRoomService roomService)
        {
            _registrationPeriodService = registrationPeriodService;
            _studentService = studentService;
            _emailService = emailService;
            _userService = userService;
            _passwordGeneratorService = passwordGeneratorService;
            _buildingService = buildingService;
            _studentHousingService = studentHousingService;
            _roomService = roomService;
        }
        #endregion
        public async Task<Response<GetRegistrationPeriodByIdResponse>> Handle(CreateRegistrationPeriodCommand request, CancellationToken cancellationToken)
        {

            var mappedPeriod = new Data.Entities.RegistrationPeriod()
            {
                From = request.From,
                To = request.To,
                IsClosed = request.IsClosed,
                RegistrationFees = request.RegistrationFees,
                AvailableFemaleSpaces = await _buildingService.GetBuildingsAvailableSpaces(EnGender.Female),
                AvailableMaleSpaces = await _buildingService.GetBuildingsAvailableSpaces(EnGender.Male)
            };

            var addedPeriod = await _registrationPeriodService.CreateAsync(mappedPeriod);
            var mappedResponse = new GetRegistrationPeriodByIdResponse()
            {
                Id = addedPeriod.Id,
                From = addedPeriod.From,
                IsClosed = addedPeriod.IsClosed,
                RegistrationFees = addedPeriod.RegistrationFees,
                To = addedPeriod.To
            };

            return Created(mappedResponse, string.Format(SharedResourcesKeys.Created, nameof(Data.Entities.RegistrationPeriod)));
        }

        public async Task<Response<GetRegistrationPeriodByIdResponse>> Handle(UpdateRegistrationPeriodCommand request, CancellationToken cancellationToken)
        {
            var oldPeriod = await _registrationPeriodService.GetAsync(request.Id);

            if (oldPeriod is null)
                return BadRequest<GetRegistrationPeriodByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.RegistrationPeriod)));

            oldPeriod.RegistrationFees = request.RegistrationFees;
            oldPeriod.From = request.From;
            oldPeriod.To = request.To;
            oldPeriod.IsClosed = request.IsClosed;
            oldPeriod.AvailableFemaleSpaces = await _buildingService.GetBuildingsAvailableSpaces(EnGender.Female);
            oldPeriod.AvailableMaleSpaces = await _buildingService.GetBuildingsAvailableSpaces(EnGender.Male);
            var updatedEvent = await _registrationPeriodService.UpdateAsync(oldPeriod);
            var mappedResponse = new GetRegistrationPeriodByIdResponse()
            {
                Id = updatedEvent.Id,
                From = updatedEvent.From,
                To = updatedEvent.To,
                IsClosed = updatedEvent.IsClosed,
                RegistrationFees = updatedEvent.RegistrationFees
            };

            return Success(mappedResponse);
        }

        public async Task<Response<bool>> Handle(DeleteRegistrationPeriodCommand request, CancellationToken cancellationToken)
        {
            var searchedPeriod = await _registrationPeriodService.GetAsync(request.RegistrationPeriodId);

            if (searchedPeriod is null)
                return BadRequest<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Data.Entities.RegistrationPeriod)));

            var isDeleted = await _registrationPeriodService.DeleteAsync(searchedPeriod);
            return isDeleted ? Deleted<bool>(string.Format(SharedResourcesKeys.Deleted, nameof(Data.Entities.RegistrationPeriod))) : InternalServerError<bool>();
        }

        public async Task<Response<bool>> Handle(CloseRegistrationPeriodCommand request, CancellationToken cancellationToken)
        {
            var period = await _registrationPeriodService.GetAsync(request.PeriodId);

            if (period == null || period.IsClosed)
                return BadRequest<bool>(SharedResourcesKeys.rejectClosed);

            period.IsClosed = true;
            var UpdatedPeriod = await _registrationPeriodService.UpdateAsync(period);

            if (UpdatedPeriod.IsClosed is false)
                return UnprocessableEntity<bool>(SharedResourcesKeys.TryAgain);

            var topStudents = await _studentService.GetTopStudents(period.AvailableMaleSpaces, period.AvailableFemaleSpaces, period.Id);
            foreach (var student in topStudents)
            {
                student.Application.FinalStatus = EnStatus.Accepted;
                var appUser = new ApplicationUser()
                {
                    Email = student.Email,
                    EmailConfirmed = true,
                    PhoneNumber = student.Phone,
                    UserName = student.Email,
                };
                var password = _passwordGeneratorService.Generate();
                var result = await _userService.CreateUser(appUser, password, "User");
                await _emailService.SendEmail(result.User.Email, student.FirstName,
                    "You are Accepted in Benha Housing." +
                    $"<br> Use these data to login:<br><strong>Username: </strong>{result.User.UserName}<br>" +
                    $"<strong>Password: </strong>{password}", "Housing System Accepting");
            }
            var allRooms = await _roomService.GetAllAsync();
            _studentHousingService.AssignStudentsToRooms(topStudents, allRooms);

            // Single call to update all students
            await _studentService.UpdateStudents(topStudents);
            return Success<bool>(true);
        }
    }
}
