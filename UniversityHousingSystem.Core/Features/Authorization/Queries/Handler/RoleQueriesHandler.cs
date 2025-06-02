using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Core.Features.Authorization.Queries.Models;
using UniversityHousingSystem.Core.Features.Authorization.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Authorization.Queries.Handler
{
    public class RoleQueriesHandler : ResponseHandler,
        IRequestHandler<GetAllRolesQuery, Response<List<GetAllRolesResponse>>>,
        IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResponse>>,
        IRequestHandler<GetUserRolesQuery, Response<GetUserRolesResponse>>
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthorizationService _authorizationService;
        #endregion

        #region Constructors
        public RoleQueriesHandler(RoleManager<IdentityRole> roleManager, IAuthorizationService authorizationService)
        {
            _roleManager = roleManager;
            _authorizationService = authorizationService;
        }
        #endregion

        #region Handlers
        public async Task<Response<List<GetAllRolesResponse>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var rolesList = await _authorizationService.GetAllRolesAsync();
            var mappedList = rolesList.Select(r => new GetAllRolesResponse
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
            return Success(mappedList);
        }

        public async Task<Response<GetRoleByIdResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleByIdAsync(request.Id);
            if (role == null)
                return NotFound<GetRoleByIdResponse>(SharedResourcesKeys.NotFound);

            var mappedRole = new GetRoleByIdResponse() { Id = role.Id, Name = role.Name };
            return Success(mappedRole);
        }

        public async Task<Response<GetUserRolesResponse>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Get User Roles
                var userRolesList = await _authorizationService.GetUserRolesAsync(request.userId);

                //Get All Roles
                var allRoles = await _roleManager.Roles.ToListAsync();

                //Map Response From AllRoles and User Roles
                var Response = new GetUserRolesResponse()
                {
                    UserId = request.userId,
                    Roles = allRoles.Select(r => new RolesInUserRolesResponse
                    {
                        RoleId = r.Id,
                        Name = r.Name,
                        HasRole = userRolesList.Contains(r.Name)
                    }).ToList()
                };
                return Success(Response);
            }
            catch (Exception ex)
            {
                return NotFound<GetUserRolesResponse>(ex.Message);
            }
        }
        #endregion
    }
}
