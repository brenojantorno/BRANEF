using branef.Domain.Models;

namespace branef.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : Entity
{
    void Create(T Entity, CancellationToken cancellationToken);
    void Update(T Entity);
    void Delete(T Entity);
    Task<T?> FindAsync(Guid Id, CancellationToken cancellationToken);
}