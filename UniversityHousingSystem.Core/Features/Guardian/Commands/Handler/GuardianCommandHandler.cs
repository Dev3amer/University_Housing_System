using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Buildings.Commands.Handler
{
    public class GuardianCommandHandler : ResponseHandler,
      IRequestHandler<CreateGuardianCommand, Response<GetGuardianByIdResponse>>,
     IRequestHandler<UpdateGuardianCommand, Response<GetGuardianByIdResponse>>,
     IRequestHandler<DeleteGuardianCommand, Response<bool>>
    {
        #region Fields
        private readonly IGuardianService _guardianService;
       // private readonly ICurrentUserService _currentUserService;
     //   private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructor
        public GuardianCommandHandler(
            IGuardianService guardianService)
        {
            _guardianService = guardianService;
        
        }
        #endregion

        #region Handlers

        public async Task<Response<GetGuardianByIdResponse>> Handle(CreateGuardianCommand request, CancellationToken cancellationToken)
        {
            // Map request data to Guardian entity
            var guardian = new Guardian
            {
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                ThirdName = request.ThirdName,
                FourthName = request.FourthName,
                Job = request.Job,
                NationalId = request.NationalId,
                Phone = request.Phone,
                GuardianRelation = request.GuardianRelation
            };

            // Save guardian using the service
            var createdGuardian = await _guardianService.CreateAsync(guardian);

            // Map saved entity to response model
            var response = new GetGuardianByIdResponse
            {
                GuardianId = createdGuardian.GuardianId,
                FirstName = createdGuardian.FirstName,
                SecondName = createdGuardian.SecondName,
                ThirdName = createdGuardian.ThirdName,
                FourthName = createdGuardian.FourthName,
                Job = createdGuardian.Job,
                NationalId = createdGuardian.NationalId,
                Phone = createdGuardian.Phone,
                GuardianRelation = createdGuardian.GuardianRelation
            };

            return Created(response, string.Format(SharedResourcesKeys.Created, nameof(Guardian)));
        }


        // ********** Update Guardian **********
        public async Task<Response<GetGuardianByIdResponse>> Handle(UpdateGuardianCommand request, CancellationToken cancellationToken)
        {
            var guardian = await _guardianService.GetAsync(request.GuardianId);
            if (guardian == null)
                return NotFound<GetGuardianByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Guardian)));

            guardian.FirstName = request.FirstName;
            guardian.SecondName = request.SecondName;
            guardian.ThirdName = request.ThirdName;
            guardian.FourthName = request.FourthName;
            guardian.Job = request.Job;
            guardian.NationalId = request.NationalId;
            guardian.Phone = request.Phone;
            guardian.GuardianRelation = request.GuardianRelation;

            var updatedGuardian = await _guardianService.UpdateAsync(guardian);

            var response = new GetGuardianByIdResponse
            {
                GuardianId = updatedGuardian.GuardianId,
                FirstName = updatedGuardian.FirstName,
                SecondName = updatedGuardian.SecondName,
                ThirdName = updatedGuardian.ThirdName,
                FourthName = updatedGuardian.FourthName,
                Job = updatedGuardian.Job,
                NationalId = updatedGuardian.NationalId,
                Phone = updatedGuardian.Phone,
                GuardianRelation = updatedGuardian.GuardianRelation
            };

            return Success(response);
        }

        // ********** Delete Guardian **********
        public async Task<Response<bool>> Handle(DeleteGuardianCommand request, CancellationToken cancellationToken)
        {
            var guardian = await _guardianService.GetAsync(request.GuardianId);
            if (guardian == null)
                return NotFound<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Guardian)));

            var result = await _guardianService.DeleteAsync(guardian);
            return Success(result);
        }

        #endregion
    }
}

