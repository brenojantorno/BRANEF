using branef.Domain.Interfaces.Repositories;
using branef.Infrastructure.Data;

namespace branef.Infrastructure.Repositories;

public class UnitOfWork(BranefContext _context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);
}