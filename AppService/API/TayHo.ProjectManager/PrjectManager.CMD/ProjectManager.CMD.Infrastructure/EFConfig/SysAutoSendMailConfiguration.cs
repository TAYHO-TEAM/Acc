using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class SysAutoSendMailConfiguration : IEntityTypeConfiguration<SysAutoSendMail>
    {
        public void Configure(EntityTypeBuilder<SysAutoSendMail> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.SysAutoSendMail_TABLENAME);
            builder.Property(x => x.SysJobId).HasField("_sysJobId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TemplateMailId).HasField("_templateMailId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SubMail).HasField("_subMail").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TitleMail).HasField("_titleMail").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BodyMail).HasField("_bodyMail").UsePropertyAccessMode(PropertyAccessMode.Field);
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

        }
    }
}
