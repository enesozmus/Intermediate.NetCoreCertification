using AutoMapper;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Intermediate.Application.Features.ResidentsOperations;

public class GetResidentsQueryHandler : IRequestHandler<GetResidentsQueryRequest, Result<IReadOnlyList<GetResidentsQueryResponse>>>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly IMapper _mapper;

     public GetResidentsQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
     {
          _userManager = userManager;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetResidentsQueryResponse>>> Handle(GetResidentsQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var residents = await _userManager.Users.ToListAsync();

          // eşle
          var mapped = _mapper.Map<IReadOnlyList<GetResidentsQueryResponse>>(residents);

          // gönder
          return Result<IReadOnlyList<GetResidentsQueryResponse>>.Success(mapped);
     }
}
