using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class HandOverReceiptConfiguration
    {
        public void Configure(EntityTypeBuilder<HandOverReceipt> builder)
        {
            builder.ToTable(OperationManagerConstants.HandOverReceipt_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasColumnName("Description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasColumnName("Note").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.WarehouseStorageId).HasColumnName("WarehouseStorageId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendAddress).HasColumnName("SendAddress").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendStreet).HasColumnName("SendStreet").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendDistrict).HasColumnName("SendDistrict").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendWard).HasColumnName("SendWard").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendCity).HasColumnName("SendCity").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendCountry).HasColumnName("SendCountry").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveAddress).HasColumnName("ReceiveAddress").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveStreet).HasColumnName("ReceiveStreet").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveDistrict).HasColumnName("ReceiveDistrict").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveWard).HasColumnName("ReceiveWard").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveCity).HasColumnName("ReceiveCity").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveCountry).HasColumnName("ReceiveCountry").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsInOrOut).HasColumnName("IsInOrOut").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
