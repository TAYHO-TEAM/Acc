using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class SysAutoSendMailConfiguration
    {
        public void Configure(EntityTypeBuilder<SysAutoSendMail> builder)
        {
            builder.ToTable(ProjectManagerConstants.SysAutoSendMail_TABLENAME);
           builder.Property(x => x.SysJobId).HasColumnName("SysJobId").UsePropertyAccessMode(PropertyAccessMode.Field);
	builder.Property(x => x.TemplateMailId).HasColumnName("TemplateMailId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.SubMail).HasColumnName("SubMail").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.TitleMail).HasColumnName("TitleMail").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.BodyMail).HasColumnName("BodyMail").UsePropertyAccessMode(PropertyAccessMode.Field);
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
			
        }
    }
}
