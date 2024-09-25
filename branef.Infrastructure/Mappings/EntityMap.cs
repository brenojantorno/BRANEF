
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using branef.Domain.Models;

namespace branef.Infrastructure.Mappings;

public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);

        //Configurar o datetime2(0) evita que seja salvo precisão desnecessária para esse contexto, além de consumir 6 bytes ao inves de 8 
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2(0)").IsRequired();
        builder.Property(x => x.UpdatedAt).HasColumnType("datetime2(0)");
        ConfigureContent(builder);
    }

    public abstract void ConfigureContent(EntityTypeBuilder<TEntity> builder);
}