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
            builder.Property(x => x.SendStreetId).HasColumnName("SendStreetId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendDistrictId).HasColumnName("SendDistrictId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendWardId).HasColumnName("SendWardId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendCityId).HasColumnName("SendCityId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendCountryId).HasColumnName("SendCountryId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveAddress).HasColumnName("ReceiveAddress").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveStreetId).HasColumnName("ReceiveStreetId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveDistrictId).HasColumnName("ReceiveDistrictId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveWardId).HasColumnName("ReceiveWardId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveCityId).HasColumnName("ReceiveCityId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReceiveCountryId).HasColumnName("ReceiveCountryId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsInOrOut).HasColumnName("IsInOrOut").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
