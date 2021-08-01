using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class ComplaintDetailConfiguration
    {
        public void Configure(EntityTypeBuilder<ComplaintDetail> builder)
        {
            builder.ToTable(OperationManagerConstants.ComplaintDetail_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ComplaintId).HasColumnName("ComplaintId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ComplaintsTypeId).HasColumnName("ComplaintsTypeId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
