using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NotifyConfigLogConfiguration : IEntityTypeConfiguration<NotifyConfigLog>
    {
        public void Configure(EntityTypeBuilder<NotifyConfigLog> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NotifyConfigLog_TABLENAME);
            builder.Property(x => x.NotifyConfigId).HasField("_notifyConfigId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.OwnerById).HasField("_ownerById").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
