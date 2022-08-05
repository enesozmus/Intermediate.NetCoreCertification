using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentsOperations;

public class RemoveApartmentCommandRequest : IRequest<Result<Unit>>
{
     public int Id { get; set; }
}
