using AutoMapper;
using Intermediate.Application.Interfaces;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class SendMessageCommandHandler : IRequestHandler<SendMessageCommandRequest, Result<Unit>>
{
     private readonly IMessageWriteRepository _writeRepository;
     private readonly IUserAccessor _userAccessor;
     private readonly IMapper _mapper;

     public SendMessageCommandHandler(IMessageWriteRepository writeRepository, IUserAccessor userAccessor, IMapper mapper)
     {
          _writeRepository = writeRepository;
          _userAccessor = userAccessor;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(SendMessageCommandRequest request, CancellationToken cancellationToken)
     {
          // eşle
          var mapped = _mapper.Map<Message>(request);

          // giriş yapan kullanıcı ile mesajı gönderen ID'sini eşle 
          mapped.SendUserId = _userAccessor.GetUserId();

          // oluştur
          await _writeRepository.AddAsync(mapped);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

