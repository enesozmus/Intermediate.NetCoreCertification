using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentsOperations;

public class GetApartmentsQueryHandler : IRequestHandler<GetApartmentsQueryRequest, Result<IReadOnlyList<GetApartmentsQueryResponse>>>
{
     private readonly IApartmentReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetApartmentsQueryHandler(IApartmentReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetApartmentsQueryResponse>>> Handle(GetApartmentsQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var apartments = await _readRepository.GetApartments();

          // eşle
          var mapped = _mapper.Map<IReadOnlyList<GetApartmentsQueryResponse>>(apartments);

          // gönder
          return Result<IReadOnlyList<GetApartmentsQueryResponse>>.Success(mapped);
     }
}
