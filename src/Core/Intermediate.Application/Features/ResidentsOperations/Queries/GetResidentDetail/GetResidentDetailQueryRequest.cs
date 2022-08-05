using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ResidentsOperations;

public class GetResidentDetailQueryRequest : IRequest<Result<GetResidentDetailQueryResponse>>
{
     public int Id { get; set; }
}
