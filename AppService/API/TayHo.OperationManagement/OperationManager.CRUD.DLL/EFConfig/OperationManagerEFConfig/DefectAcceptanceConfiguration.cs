using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class DefectAcceptanceConfiguration
    {
        public void Configure(EntityTypeBuilder<DefectAcceptance> builder)
        {
            builder.ToTable(OperationManagerConstants.DefectAcceptance_TABLENAME);
            builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DefectFixId).HasColumnName("DefectFixId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DefectFeedbackId).HasColumnName("DefectFeedbackId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DefectFeedbackDetailId).HasColumnName("DefectFeedbackDetailId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CustomerInfoId).HasColumnName("CustomerInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasColumnName("Note").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
