using AutoMapper;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Intermediate.Application.Features.ResidentsOperations;

public class UpdateResidentCommandHandler : IRequestHandler<UpdateResidentCommandRequest, Result<Unit>>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly IMapper _mapper;

     public UpdateResidentCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
     {
          _userManager = userManager;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(UpdateResidentCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var user = _userManager.Users.Where(x => x.Id == request.Id).FirstOrDefault();
          if (user == null)
               return null;

          // eşle
          _mapper.Map(request, user);

          // güncelle
          await _userManager.UpdateAsync(user);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

