using AutoMapper;
using Intermediate.Application.Interfaces;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Intermediate.Application.Features.ProfilesOperations;

public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, Result<GetUserQueryResponse>>
{
     private readonly IUserAccessor _userAccessor;
     private readonly UserManager<AppUser> _userManager;
     private readonly IMapper _mapper;

     public GetUserQueryHandler(IUserAccessor userAccessor, UserManager<AppUser> userManager, IMapper mapper)
     {
          _userAccessor = userAccessor;
          _userManager = userManager;
          _mapper = mapper;
     }

     public async Task<Result<GetUserQueryResponse>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var user = await _userManager
               .Users
               //.Include(x => x.AppUserPhotos)
               .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

          if (user == null) return null;

          // eşle
          var mapped = _mapper.Map<GetUserQueryResponse>(user);

          // gönder
          return Result<GetUserQueryResponse>.Success(mapped);
     }
}