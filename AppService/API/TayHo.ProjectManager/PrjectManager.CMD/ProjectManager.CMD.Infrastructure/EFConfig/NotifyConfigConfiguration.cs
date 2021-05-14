using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NotifyConfigConfiguration : IEntityTypeConfiguration<NotifyConfig>
    {
        public void Configure(EntityTypeBuilder<NotifyConfig> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NotifyConfig_TABLENAME);
            builder.Property(x => x.Type).HasField("_type").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.JobName).HasField("_jobName").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TableName).HasField("_tableName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.QuerryCMD).HasField("_querryCMD").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
