using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BillsOperations;

public class RemoveBillCommandHandler : IRequestHandler<RemoveBillCommandRequest, Result<Unit>>
{
     private readonly IBillReadRepository _readRepository;
     private readonly IBillWriteRepository _writeRepository;

     public RemoveBillCommandHandler(IBillReadRepository readRepository, IBillWriteRepository writeRepository)
     {
          _readRepository = readRepository;
          _writeRepository = writeRepository;
     }

     public async Task<Result<Unit>> Handle(RemoveBillCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var bill = await _readRepository.GetByIdAsync(request.Id);

          // sil
          await _writeRepository.RemoveAsync(bill);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}
