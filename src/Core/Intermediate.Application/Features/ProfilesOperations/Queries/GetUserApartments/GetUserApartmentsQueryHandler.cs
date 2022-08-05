using AutoMapper;
using Intermediate.Application.Interfaces;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ProfilesOperations;

public class GetUserApartmentsQueryHandler : IRequestHandler<GetUserApartmentsQueryRequest, Result<IReadOnlyList<GetUserApartmentsQueryResponse>>>
{
     private readonly IUserAccessor _userAccessor;
     private readonly IApartmentReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetUserApartmentsQueryHandler(IUserAccessor userAccessor, IApartmentReadRepository readRepository, IMapper mapper)
     {
          _userAccessor = userAccessor;
          _readRepository = readRepository;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetUserApartmentsQueryResponse>>> Handle(GetUserApartmentsQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var apartments = await _readRepository.GetUserApartments(x => x.AppUser.UserName == _userAccessor.GetUsername());

          if (apartments == null) return null;

          // eşle
          var mapped = _mapper.Map<IReadOnlyList<GetUserApartmentsQueryResponse>>(apartments);

          // gönder
          return Result<IReadOnlyList<GetUserApartmentsQueryResponse>>.Success(mapped);
     }
}