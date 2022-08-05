using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentTypesOperations;

public class GetApartmentTypeDetailQueryHandler : IRequestHandler<GetApartmentTypeDetailQueryRequest, Result<GetApartmentTypesQueryResponse>>
{
     private readonly IApartmentTypeReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetApartmentTypeDetailQueryHandler(IApartmentTypeReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }
     public async Task<Result<GetApartmentTypesQueryResponse>> Handle(GetApartmentTypeDetailQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var apartmentType = await _readRepository.GetByIdAsync(request.Id);

          // eşle
          var mapped = _mapper.Map<GetApartmentTypesQueryResponse>(apartmentType);

          // gönder
          return Result<GetApartmentTypesQueryResponse>.Success(mapped);
     }
}
