using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BillsOperations;

public class GetBillDetailQueryHandler : IRequestHandler<GetBillDetailQueryRequest, Result<GetBillsQueryResponse>>
{
     private readonly IBillReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetBillDetailQueryHandler(IBillReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }
     public async Task<Result<GetBillsQueryResponse>> Handle(GetBillDetailQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var bill = await _readRepository.GetBill(request.Id);

          // eşle
          var mapped = _mapper.Map<GetBillsQueryResponse>(bill);

          // gönder
          return Result<GetBillsQueryResponse>.Success(mapped);
     }
}
