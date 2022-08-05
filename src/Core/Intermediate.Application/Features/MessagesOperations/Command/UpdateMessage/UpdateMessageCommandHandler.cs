using AutoMapper;
using Intermediate.Application.Interfaces;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommandRequest, Result<Unit>>
{
     private readonly IUserAccessor _userAccessor;
     private readonly IMessageReadRepository _readRepository;
     private readonly IMessageWriteRepository _writeRepository;
     private readonly IMapper _mapper;

     public UpdateMessageCommandHandler(IUserAccessor userAccessor, IMessageReadRepository readRepository, IMessageWriteRepository writeRepository, IMapper mapper)
     {
          _userAccessor = userAccessor;
          _readRepository = readRepository;
          _writeRepository = writeRepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(UpdateMessageCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var message = await _readRepository.GetByIdAsync(request.Id);

          // eşle
          _mapper.Map(request, message);

          // güncelle
          if (message.SendUserId == _userAccessor.GetUserId())
          {
               await _writeRepository.UpdateAsync(message);
               return Result<Unit>.Success(Unit.Value);
          }
          else
               return null;
     }
}

