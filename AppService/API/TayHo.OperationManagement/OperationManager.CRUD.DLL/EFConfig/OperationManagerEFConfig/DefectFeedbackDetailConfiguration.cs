using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class DefectFeedbackDetailConfiguration
    {
        public void Configure(EntityTypeBuilder<DefectFeedbackDetail> builder)
        {
            builder.ToTable(OperationManagerConstants.DefectFeedbackDetail_TABLENAME);
            builder.Property(x => x.DefectFeedbackId).HasColumnName("DefectFeedbackId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DefectiveId).HasColumnName("DefectiveId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasColumnName("Note").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartDate).HasColumnName("StartDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FinishDate).HasColumnName("FinishDate").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
