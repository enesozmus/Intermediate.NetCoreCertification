using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Intermediate.Application.Features.ResidentsOperations;

public class RemoveResidentCommandHandler : IRequestHandler<RemoveResidentCommandRequest, Result<Unit>>
{
     private readonly UserManager<AppUser> _userManager;

     public RemoveResidentCommandHandler(UserManager<AppUser> userManager)
     {
          _userManager = userManager;
     }

     public async Task<Result<Unit>> Handle(RemoveResidentCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var model = _userManager.Users.Where(x => x.Id == request.Id).FirstOrDefault();

          // sil
          await _userManager.DeleteAsync(model);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}
