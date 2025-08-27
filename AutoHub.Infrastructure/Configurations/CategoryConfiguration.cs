namespace VehicleAutoHub.Infrastructure.Configurations;

public class CategoryConfiguration: BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        
        // Table_Name, Index, PK_Name
        builder.ToTable("Categories");
        
        builder.HasIndex(m => m.Name);
        
        builder.Property(m => m.Id).HasColumnName("PK_Category_Id");
        
        
        // Columns_Name_Length

        builder.Property(m => m.Name).HasColumnName("CategoryName").HasMaxLength(30);
        
        builder.Property(m => m.Description).HasColumnName("CategoryDescription").HasMaxLength(500);
    }
}