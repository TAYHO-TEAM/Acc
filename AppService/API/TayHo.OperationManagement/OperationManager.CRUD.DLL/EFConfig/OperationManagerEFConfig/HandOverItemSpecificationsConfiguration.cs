using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class HandOverItemSpecificationsConfiguration
    {
        public void Configure(EntityTypeBuilder<HandOverItemSpecifications> builder)
        {
            builder.ToTable(OperationManagerConstants.HandOverItemSpecifications_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HandOverItemId).HasColumnName("HandOverItemId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Parentid).HasColumnName("Parentid").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CategoryUnitId).HasColumnName("CategoryUnitId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Quantity).HasColumnName("Quantity").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasColumnName("Description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
