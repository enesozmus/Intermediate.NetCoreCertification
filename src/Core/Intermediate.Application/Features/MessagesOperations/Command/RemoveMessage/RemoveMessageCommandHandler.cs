using Intermediate.Application.Interfaces;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class RemoveMessageCommandHandler : IRequestHandler<RemoveMessageCommandRequest, Result<Unit>>
{
     private readonly IUserAccessor _userAccessor;
     private readonly IMessageReadRepository _readRepository;
     private readonly IMessageWriteRepository _writeRepository;

     public RemoveMessageCommandHandler(IUserAccessor userAccessor, IMessageReadRepository readRepository, IMessageWriteRepository writeRepository)
     {
          _userAccessor = userAccessor;
          _readRepository = readRepository;
          _writeRepository = writeRepository;
     }

     public async Task<Result<Unit>> Handle(RemoveMessageCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var message = await _readRepository.GetByIdAsync(request.Id);

          // kullanıcı sadece kendi attığı mesajı silebilsin
          if (message.SendUserId == _userAccessor.GetUserId())
          {
               await _writeRepository.RemoveAsync(message);
               return Result<Unit>.Success(Unit.Value);
          } 
          else
               return null;
     }
}
