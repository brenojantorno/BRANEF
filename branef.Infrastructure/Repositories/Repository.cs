using branef.Domain.Interfaces.Repositories;
using branef.Domain.Models;
using branef.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace branef.Infrastructure.Repositories;

public class Repository<T>(BranefContext context) : IRepository<T> where T : Entity
{
    protected readonly BranefContext _db = context;
    protected readonly DbSet<T> _dbset = context.Set<T>();

    public async void Create(T Entity, CancellationToken cancellationToken)
    {
        Entity.SetId();
        await _dbset.AddAsync(Entity, cancellationToken);
    }
    public void Update(T Entity)
    {
        Entity.SetUpdateDate();
        _dbset.Update(Entity);
    }
    public void Delete(T Entity) => _dbset.Remove(Entity);

    public async Task<T?> FindAsync(Guid Id, CancellationToken cancellationToken) => await _dbset.FindAsync(Id, cancellationToken);

}