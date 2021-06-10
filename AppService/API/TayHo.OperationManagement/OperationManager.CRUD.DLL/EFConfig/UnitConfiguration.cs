using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class UnitConfiguration
    {
        public void Configure(EntityTypeBuilder<CategoryUnit> builder)
        {
            builder.ToTable(OperationManagerConstants.CategoryUnit_TABLENAME);
            builder.Property(x => x.ParentId).HasColumnName("ParentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
