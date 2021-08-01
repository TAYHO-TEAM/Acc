using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class DefectFixConfiguration
    {
        public void Configure(EntityTypeBuilder<DefectFix> builder)
        {
            builder.ToTable(OperationManagerConstants.DefectFix_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DefectFeedbackId).HasColumnName("DefectFeedbackId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Times).HasColumnName("Times").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ParentId).HasColumnName("ParentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.MaintenanceSupplierInfoId).HasColumnName("MaintenanceSupplierInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.MaintenancerInfoId).HasColumnName("MaintenancerInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Fixer).HasColumnName("Fixer").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FixerPhone).HasColumnName("FixerPhone").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartDate).HasColumnName("StartDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndDate).HasColumnName("EndDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Deadline).HasColumnName("Deadline").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FixedDate).HasColumnName("FixedDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Result).HasColumnName("Result").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ResultType).HasColumnName("ResultType").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasColumnName("Note").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
