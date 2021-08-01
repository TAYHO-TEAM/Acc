using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class SysTemplateReportConfiguration
    {
        public void Configure(EntityTypeBuilder<SysTemplateReport> builder)
        {
            builder.ToTable(ProjectManagerConstants.SysTemplateReport_TABLENAME);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(32).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FileName).HasColumnName("FileName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DisplayName).HasColumnName("DisplayName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Tail).HasColumnName("Tail").HasMaxLength(10).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Url).HasColumnName("Url").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Host).HasColumnName("Host").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").HasMaxLength(50).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Direct).HasColumnName("Direct").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
