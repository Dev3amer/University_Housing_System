using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Core.Features.Users.Queries.Models;
using UniversityHousingSystem.Core.Features.Users.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace MovieReservationSystem.Core.Features.Users.Queries.Handler
{
    public class UserQueryHandler : ResponseHandler,
       IRequestHandler<GetAllUsersQuery, Response<List<GetAllUsersResponse>>>,
       IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        #endregion

        #region Constructors
        public UserQueryHandler(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }
        #endregion
        public async Task<Response<List<GetAllUsersResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersList = await _userManager.Users.Select(u => new GetAllUsersResponse
            {
                Id = u.Id,
                FullName = $"{u.Student.FirstName} {u.Student.SecondName} {u.Student.ThirdName} {u.Student.FourthName}",
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                UserName = u.UserName
            }).ToListAsync();

            return Success(usersList);
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var userMappedIntoResponse = await _userManager.Users.Where(u => u.Id == request.Id)
            .Select(u => new GetUserByIdResponse
            {
                FullName = $"{u.Student.FirstName} {u.Student.SecondName} {u.Student.ThirdName} {u.Student.FourthName}",
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                UserName = u.UserName
            }).FirstOrDefaultAsync();

            if (userMappedIntoResponse is null)
                return NotFound<GetUserByIdResponse>(SharedResourcesKeys.NotFound);

            return Success(userMappedIntoResponse);
        }
    }
}
