using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Core.Features.Authorization.Commands.Models;
using UniversityHousingSystem.Core.Features.Authorization.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Service.Abstractions;

namespace MovieReservationSystem.Core.Features.Authorization.Commands.Handler
{
    public class RoleCommandsHandler : ResponseHandler,
        IRequestHandler<CreateRoleCommand, Response<GetRoleByIdResponse>>,
        IRequestHandler<EditRoleCommand, Response<GetRoleByIdResponse>>,
        IRequestHandler<DeleteRoleCommand, Response<bool>>,
        IRequestHandler<UpdateUserRolesCommand, Response<GetUserRolesResponse>>
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthorizationService _authorizationService;

        #endregion

        #region Constructors
        public RoleCommandsHandler(RoleManager<IdentityRole> roleManager, IAuthorizationService authorizationService)
        {
            _roleManager = roleManager;
            _authorizationService = authorizationService;
        }
        #endregion

        #region Actions
        public async Task<Response<GetRoleByIdResponse>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedRole = await _authorizationService.CreateRoleAsync(request.Name);
                var mappedRole = new GetRoleByIdResponse { Id = updatedRole.Id, Name = updatedRole.Name };
                return Created(mappedRole);
            }
            catch (Exception ex)
            {
                return BadRequest<GetRoleByIdResponse>(ex.Message);
            }
        }

        public async Task<Response<GetRoleByIdResponse>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedRole = await _authorizationService.EditRoleAsync(request.Id, request.Name);
                var mappedRole = new GetRoleByIdResponse { Id = updatedRole.Id, Name = updatedRole.Name };
                return Success(mappedRole);
            }
            catch (Exception ex)
            {
                return BadRequest<GetRoleByIdResponse>(ex.Message);
            }
        }

        public async Task<Response<bool>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var identityResult = await _authorizationService.DeleteRoleAsync(request.RoleId);
                if (!identityResult.Succeeded)
                    return BadRequest<bool>(identityResult.Errors.FirstOrDefault().Description);
                return Deleted<bool>();
            }
            catch (Exception ex)
            {
                return BadRequest<bool>(ex.Message);
            }
        }

        public async Task<Response<GetUserRolesResponse>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedUserRoles = await _authorizationService.UpdateUserRolesAsync(request.UserId, request.RolesNames);

                //Get All Roles
                var allRoles = await _roleManager.Roles.ToListAsync();

                //Map Response From AllRoles and User Roles
                var Response = new GetUserRolesResponse()
                {
                    UserId = request.UserId,
                    Roles = allRoles.Select(r => new RolesInUserRolesResponse
                    {
                        RoleId = r.Id,
                        Name = r.Name,
                        HasRole = updatedUserRoles.Contains(r.Name)
                    }).ToList()
                };
                return Success(Response);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound<GetUserRolesResponse>(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest<GetUserRolesResponse>(ex.Message);
            }
        }
        #endregion
    }
}
