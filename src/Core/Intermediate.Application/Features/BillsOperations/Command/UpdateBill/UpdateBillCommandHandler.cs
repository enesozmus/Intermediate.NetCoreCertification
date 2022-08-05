using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BillsOperations;

public class UpdateBillCommandHandler : IRequestHandler<UpdateBillCommandRequest, Result<Unit>>
{
     private readonly IBillReadRepository _readRepository;
     private readonly IBillWriteRepository _writeRepository;
     private readonly IMapper _mapper;

     public UpdateBillCommandHandler(IBillReadRepository readRepository, IBillWriteRepository writeRepository, IMapper mapper)
     {
          _readRepository = readRepository;
          _writeRepository = writeRepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(UpdateBillCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var bill = await _readRepository.GetByIdAsync(request.Id);

          // eşle
          _mapper.Map(request, bill);

          // güncelle
          await _writeRepository.UpdateAsync(bill);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

