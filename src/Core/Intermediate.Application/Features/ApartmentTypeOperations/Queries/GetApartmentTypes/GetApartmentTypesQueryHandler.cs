using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentTypesOperations;

public class GetApartmentTypesQueryHandler : IRequestHandler<GetApartmentTypesQueryRequest, Result<IReadOnlyList<GetApartmentTypesQueryResponse>>>
{
     private readonly IApartmentTypeReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetApartmentTypesQueryHandler(IApartmentTypeReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetApartmentTypesQueryResponse>>> Handle(GetApartmentTypesQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var apartmentTypes = await _readRepository.GetAllAsync();

          // eşle
          var mapped = _mapper.Map<IReadOnlyList<GetApartmentTypesQueryResponse>>(apartmentTypes);

          // gönder
          return Result<IReadOnlyList<GetApartmentTypesQueryResponse>>.Success(mapped);
     }
}
