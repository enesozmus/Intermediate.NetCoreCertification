using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BillsOperations;

public class PayTheBillCommandHandler : IRequestHandler<PayTheBillCommandRequest, Result<Unit>>
{
     private readonly IBillReadRepository _readRepository;
     private readonly IBillWriteRepository _writeRepository;

     public PayTheBillCommandHandler(IBillReadRepository readRepository, IBillWriteRepository writeRepository)
     {
          _readRepository = readRepository;
          _writeRepository = writeRepository;
     }

     public async Task<Result<Unit>> Handle(PayTheBillCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var bill = await _readRepository.GetByIdAsync(request.Id);

          // ödendi mi bilgisini güncelle
          if (bill.IsPaid)
               bill.IsPaid = false;
          else
               bill.IsPaid = true;

          // değişikliği kaydet
          await _writeRepository.SaveAsync();

          // sonucu gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

