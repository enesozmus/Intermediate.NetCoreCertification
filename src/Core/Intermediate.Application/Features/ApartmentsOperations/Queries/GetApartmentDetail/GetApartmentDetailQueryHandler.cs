using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentsOperations;

public class GetApartmentDetailQueryHandler : IRequestHandler<GetApartmentDetailQueryRequest, Result<GetApartmentsQueryResponse>>
{
     private readonly IApartmentReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetApartmentDetailQueryHandler(IApartmentReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }
     public async Task<Result<GetApartmentsQueryResponse>> Handle(GetApartmentDetailQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var apartment = await _readRepository.GetApartment(request.Id);

          // eşle
          var mapped = _mapper.Map<GetApartmentsQueryResponse>(apartment);

          // gönder
          return Result<GetApartmentsQueryResponse>.Success(mapped);
     }
}
