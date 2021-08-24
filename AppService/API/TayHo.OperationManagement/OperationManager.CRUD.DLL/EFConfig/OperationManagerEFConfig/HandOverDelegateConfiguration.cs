using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class HandOverDelegateConfiguration
    {
        public void Configure(EntityTypeBuilder<HandOverDelegate> builder)
        {
            builder.ToTable(OperationManagerConstants.HandOverDelegate_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HandOverReceiptId).HasColumnName("HandOverReceiptId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FullName).HasColumnName("FullName").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasColumnName("Description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PhoneContact).HasColumnName("PhoneContact").HasMaxLength(32).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsSenderOrReceiver).HasColumnName("IsSenderOrReceiver").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
