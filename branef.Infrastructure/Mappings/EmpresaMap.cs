
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using branef.Domain.Models;

namespace branef.Infrastructure.Mappings;

public class EmpresaMap : EntityMap<Empresa>
{
    public override void ConfigureContent(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresa");
        builder.Property(x => x.Nome).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Porte).IsRequired();
    }
}