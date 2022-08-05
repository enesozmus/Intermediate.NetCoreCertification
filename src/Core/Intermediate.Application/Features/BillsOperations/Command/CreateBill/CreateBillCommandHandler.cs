using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;

namespace Intermediate.Application.Features.BillsOperations;

public class CreateBillCommandHandler : IRequestHandler<CreateBillCommandRequest, Result<Unit>>
{
     private readonly IBillWriteRepository _writeRepository;
     private readonly IMapper _mapper;

     public CreateBillCommandHandler(IBillWriteRepository writeRepository, IMapper mapper)
     {
          _writeRepository = writeRepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(CreateBillCommandRequest request, CancellationToken cancellationToken)
     {
          // eşle
          var mapped = _mapper.Map<Bill>(request);

          // oluştur
          await _writeRepository.AddAsync(mapped);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

