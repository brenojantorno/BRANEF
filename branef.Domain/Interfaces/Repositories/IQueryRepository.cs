using branef.Domain.Models;

namespace branef.Domain.Interfaces.Repositories;

public interface IQueryRepository<T> where T : Entity
{
    Task Create(T Entity, CancellationToken cancellationToken);
    Task Update(T Entity, CancellationToken cancellationToken);
    Task Delete(T Entity, CancellationToken cancellationToken);
    Task<T?> FindAsync(Guid Id, CancellationToken cancellationToken);
    Task<List<T>?> GetAll(CancellationToken cancellationToken);
}