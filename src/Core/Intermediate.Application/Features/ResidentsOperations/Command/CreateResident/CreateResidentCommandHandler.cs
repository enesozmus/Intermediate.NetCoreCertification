using AutoMapper;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Intermediate.Application.Features.ResidentsOperations;

public class CreateResidentCommandHandler : IRequestHandler<CreateResidentCommandRequest, Result<Unit>>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly IMapper _mapper;

     public CreateResidentCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
     {
          _userManager = userManager;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(CreateResidentCommandRequest request, CancellationToken cancellationToken)
     {
          // eşle
          var userEntity = _mapper.Map<AppUser>(request);

          // oluştur
          var result = await _userManager.CreateAsync(userEntity, request.Password);
          if (!result.Succeeded)
               throw new ResidentCreateFailedException();

          // rolünü ekle
          await _userManager.AddToRoleAsync(userEntity, "User");

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}
