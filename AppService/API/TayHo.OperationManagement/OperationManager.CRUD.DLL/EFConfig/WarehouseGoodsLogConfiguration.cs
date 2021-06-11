using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class WarehouseGoodsLogConfiguration
    {
        public void Configure(EntityTypeBuilder<WarehouseGoodsLog> builder)
        {
            builder.ToTable(OperationManagerConstants.WarehouseGoodsLog_TABLENAME);
            builder.Property(x => x.WarehouseStorageId).HasColumnName("WarehouseStorageId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CategoryGoodsId).HasColumnName("CategoryGoodsId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Quantity).HasColumnName("Quantity").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasColumnName("Description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CheckInDate).HasColumnName("CheckInDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CheckOutDate).HasColumnName("CheckOutDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CheckInBy).HasColumnName("CheckInBy").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Sender).HasColumnName("Sender").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CheckOutBy).HasColumnName("CheckOutBy").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Receiver).HasColumnName("Receiver").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PhoneContact).HasColumnName("PhoneContact").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsInOrOut).HasColumnName("IsInOrOut").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
