using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Employees.Commands.Models;
using UniversityHousingSystem.Core.Features.Employees.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;
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
            var newEmployeeUser = new ApplicationUser()
            {
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
            };
            var randomPassword = _passwordGeneratorService.Generate();
            try
            {
                newEmployeeUser = await _userService.CreateUser(newEmployeeUser, randomPassword);
                await _userManager.RemoveFromRoleAsync(newEmployeeUser, "User");
                await _userManager.AddToRoleAsync(newEmployeeUser, "Employee");

            }
            catch (Exception ex)
            {
                return BadRequest<GetEmployeeByIdResponse>(ex.Message);
            }

            var mappedEmployee = new Employee()
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
            var message = $"<!DOCTYPE html>\r\n<html>\r\n  <head></head>\r\n  <body style=\"font-family: Arial, sans-serif; line-height: 1.6; color: #333; background-color: #f9f9f9; margin: 0; padding: 0;\">\r\n    <div style=\"max-width: 600px; margin: 20px auto; background: #ffffff; border: 1px solid #dddddd; border-radius: 8px; overflow: hidden;\">\r\n      <div style=\"background: #4caf50; color: #ffffff; text-align: center; padding: 20px;\">\r\n        <h2 style=\"margin: 0;\">Your Login Information</h2>\r\n      </div>\r\n      <div style=\"padding: 20px; text-align: left;\">\r\n        <h1 style=\"font-size: 24px; color: #4caf50; margin: 0;\">Hello, {userFullName}!</h1>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\">\r\n          Thank you for registering with us. Below you will find your login information for the Cinema App.\r\n        </p>\r\n        <div style=\"background-color: #f5f5f5; border-left: 4px solid #4caf50; padding: 15px; margin: 20px 0;\">\r\n          <p style=\"margin: 5px 0; font-size: 16px;\"><strong>Username:</strong> {newEmployeeUser.UserName}</p>\r\n          <p style=\"margin: 5px 0; font-size: 16px;\"><strong>Password:</strong> {randomPassword}</p>\r\n        </div>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\">\r\n          You can now log in to your account using the button below:\r\n        </p>\r\n        <a href='{loginURL}' style=\"display: inline-block; padding: 10px 20px; margin-top: 20px; background: #4caf50; color: #ffffff; text-decoration: none; border-radius: 4px; font-size: 16px;\">Log In Now</a>\r\n        <p style=\"margin: 20px 0 10px 0; font-size: 16px;\">\r\n          If the button above doesn't work, you can copy and paste the following link into your browser:\r\n        </p>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\"><a href='{loginURL}' style=\"color: #4caf50; text-decoration: underline;\">{loginURL}</a></p>\r\n        <p style=\"margin: 20px 0 10px 0; font-size: 16px;\">\r\n          For security reasons, we recommend changing your password after your first login.\r\n        </p>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\">\r\n          If you didn't create an account with us, please contact our support team immediately.\r\n        </p>\r\n      </div>\r\n      <div style=\"background: #f1f1f1; text-align: center; padding: 10px; font-size: 12px; color: #555;\">\r\n        <p style=\"margin: 0;\">&copy; 2025 Cinema App. All rights reserved.</p>\r\n      </div>\r\n    </div>\r\n  </body>\r\n</html>";
            await _emailService.SendEmail(newEmployeeUser.Email, userFullName, message, "Housing App - Your Account Login Details");

            var mappedResponse = new GetEmployeeByIdResponse()
            {
                EmployeeId = createdEmployee.EmployeeId,
                FirstName = createdEmployee.FirstName,
                SecondName = createdEmployee.SecondName,
                ThirdName = createdEmployee.ThirdName,
                FourthName = createdEmployee.FourthName,
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
