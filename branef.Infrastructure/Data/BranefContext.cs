
using branef.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace branef.Infrastructure.Data;

public class BranefContext : DbContext
{

    public BranefContext(DbContextOptions<BranefContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpresaMap());
        base.OnModelCreating(modelBuilder);
    }
}