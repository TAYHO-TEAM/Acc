using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class SysJobConfiguration
    {
        public void Configure(EntityTypeBuilder<SysJob> builder)
        {
            builder.ToTable(ProjectManagerConstants.SysJob_TABLENAME);
           builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
	builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.SysTemplateReportId).HasColumnName("SysTemplateReportId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.JobName).HasColumnName("JobName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.NameDataBase).HasColumnName("NameDataBase").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.NameStoreProce).HasColumnName("NameStoreProce").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.ConnStringHash).HasColumnName("ConnStringHash").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Salt).HasColumnName("Salt").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.StartTime).HasColumnName("StartTime").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.EndTime).HasColumnName("EndTime").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.StartDate).HasColumnName("StartDate").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.EndDate).HasColumnName("EndDate").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.FirstDate).HasColumnName("FirstDate").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.LastDate).HasColumnName("LastDate").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.NextDate).HasColumnName("NextDate").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Times).HasColumnName("Times").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Unit).HasColumnName("Unit").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.StepTime).HasColumnName("StepTime").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.IsTemplate).HasColumnName("IsTemplate").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
