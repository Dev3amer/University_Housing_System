using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Employees.Commands.Models;
using UniversityHousingSystem.Core.Features.Employees.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Helpers.DTOs;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;
using UniversityHousingSystem.Service.Abstractions.Helpers;

namespace UniversityHousingSystem.Core.Features.Employees.Commands.Handlers
{
    public class EmployeesCommandsHandler : ResponseHandler,
        IRequestHandler<CreateEmployeeCommand, Response<GetEmployeeByIdResponse>>,
        IRequestHandler<DeleteEmployeeCommand, Response<bool>>
    {
        #region Fields
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly IPasswordGeneratorService _passwordGeneratorService;
        private readonly IEmailService _emailService;
        #endregion

        #region Constructor
        public EmployeesCommandsHandler(IEmployeeService employeeService, IUserService userService, UserManager<ApplicationUser> userManager, IPasswordGeneratorService passwordGeneratorService, IEmailService emailService)
        {
            _employeeService = employeeService;
            _userService = userService;
            _userManager = userManager;
            _passwordGeneratorService = passwordGeneratorService;
            _emailService = emailService;
        }
        #endregion
        public async Task<Response<GetEmployeeByIdResponse>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var newEmployeeUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };

            var randomPassword = _passwordGeneratorService.Generate();

            CreateUserResult result;
            try
            {
                result = await _userService.CreateUser(newEmployeeUser, randomPassword, "Employee");
            }
            catch (Exception ex)
            {
                return BadRequest<GetEmployeeByIdResponse>($"Unexpected error: {ex.Message}");
            }

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest<GetEmployeeByIdResponse>(string.Join(" | ", errors));
            }

            newEmployeeUser = result.User;

            var mappedEmployee = new Employee
            {
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                ThirdName = request.ThirdName,
                FourthName = request.FourthName,
                User = newEmployeeUser
            };

            var createdEmployee = await _employeeService.CreateAsync(mappedEmployee);

            var userFullName = $"{createdEmployee.FirstName} {createdEmployee.SecondName} {createdEmployee.ThirdName} {createdEmployee.FourthName}";
            var loginURL = $"login";

            var message = $@"<!DOCTYPE html>
<html>...<p><strong>Username:</strong> {newEmployeeUser.UserName}</p><p><strong>Password:</strong> {randomPassword}</p>...</html>";

            await _emailService.SendEmail(newEmployeeUser.Email, userFullName, message, "Housing App - Your Account Login Details");

            var mappedResponse = new GetEmployeeByIdResponse
            {
                EmployeeId = createdEmployee.EmployeeId,
                FirstName = createdEmployee.FirstName,
                SecondName = createdEmployee.SecondName,
                ThirdName = createdEmployee.ThirdName,
                FourthName = createdEmployee.FourthName,
                Email = createdEmployee.User.Email,
                PhoneNumber = createdEmployee.User.PhoneNumber,
                UserName = createdEmployee.User.UserName
            };

            return Created(mappedResponse, string.Format(SharedResourcesKeys.Created, nameof(Employee)));
        }

        public async Task<Response<bool>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var searchedEmployee = await _employeeService.GetAsync(request.EmployeeId);

            if (searchedEmployee is null)
                return BadRequest<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Employee)));

            var isDeleted = await _employeeService.DeleteAsync(searchedEmployee);
            var isEmployeeUserDeleted = await _userManager.DeleteAsync(searchedEmployee.User);

            return isDeleted && isEmployeeUserDeleted.Succeeded ? Deleted<bool>(string.Format(SharedResourcesKeys.Deleted, nameof(Employee))) : InternalServerError<bool>();
        }
    }
}
