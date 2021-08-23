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
            builder.Property(x => x.TransporterId).HasColumnName("TransporterId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Transporter).HasColumnName("Transporter").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PhoneContact).HasColumnName("PhoneContact").HasMaxLength(32).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsInOrOut).HasColumnName("IsInOrOut").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
