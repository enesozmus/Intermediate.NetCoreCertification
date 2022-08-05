using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BillsOperations;

public class GetBillsQueryHandler : IRequestHandler<GetBillsQueryRequest, Result<IReadOnlyList<GetBillsQueryResponse>>>
{
     private readonly IBillReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetBillsQueryHandler(IBillReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetBillsQueryResponse>>> Handle(GetBillsQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var bills = await _readRepository.GetBills();

          // eşle
          var mapped = _mapper.Map<IReadOnlyList<GetBillsQueryResponse>>(bills);

          // gönder
          return Result<IReadOnlyList<GetBillsQueryResponse>>.Success(mapped);
     }
}
