using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class WarehouseReleasedDetailConfiguration
    {
        public void Configure(EntityTypeBuilder<WarehouseReleasedDetail> builder)
        {
            builder.ToTable(OperationManagerConstants.WarehouseReleasedDetail_TABLENAME);
            builder.Property(x => x.WarehouseStorageId).HasColumnName("WarehouseStorageId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.WarehouseReleasedId).HasColumnName("WarehouseReleasedId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CategoryGoodsId).HasColumnName("CategoryGoodsId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Quantity).HasColumnName("Quantity").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasColumnName("Description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
