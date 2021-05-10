using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class SysJobConfiguration : IEntityTypeConfiguration<SysJob>
    {
        public void Configure(EntityTypeBuilder<SysJob> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.SysJob_TABLENAME);
            builder.Property(x => x.TemplateId).HasField("_templateId").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.JobName).HasField("_jobName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NameDataBase).HasField("_nameDataBase").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NameStoreProce).HasField("_nameStoreProce").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ConnStringHash).HasField("_connStringHash").HasMaxLength(4000).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Salt).HasField("_salt").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartTime).HasField("_startTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndTime).HasField("_endTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartDate).HasField("_startDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndDate).HasField("_endDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FirstDate).HasField("_firstDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.LastDate).HasField("_lastDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NextDate).HasField("_nextDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Times).HasField("_times").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Unit).HasField("_unit").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StepTime).HasField("_stepTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsTemplate).HasField("_isTemplate").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
