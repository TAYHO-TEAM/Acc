using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class LogEventConfiguration : IEntityTypeConfiguration<LogEvent>
    {
        public void Configure(EntityTypeBuilder<LogEvent> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.LogEvent_TABLENAME);
            builder.Property(x => x.UserId).HasField("_userId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Event).HasField("_event").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Action).HasField("_action").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.OwnerById).HasField("_ownerById").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.OwnerByTable).HasField("_ownerByTable").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FunctionId).HasField("_functionId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Message).HasField("_message").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
