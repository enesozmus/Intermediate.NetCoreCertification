using Intermediate.Domain.Entities;

namespace Intermediate.Application.IRepositories;

public interface IRepository<T> where T : BaseEntity
{
     IQueryable<T> Table { get; }
     IQueryable<T> TableNoTracking { get; }
}
