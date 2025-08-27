namespace VehicleAutoHub.Infrastructure.Configurations;

public abstract class BaseEntityConfiguration<TEntity>: IEntityTypeConfiguration<TEntity> where TEntity : Entity<int>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(be => be.Id);

        builder.Property(be => be.Id).UseIdentityColumn();
        
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired(false);
        
        builder.Property(be => be.CreatedBy)
            .IsRequired(false);

        builder.Property(e => e.LastModified)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired(false);
        
        builder.Property(be => be.LastModifiedBy)
            .IsRequired(false);

        builder.Property(be => be.IsDeleted)
            .HasDefaultValue(false);
    }
}