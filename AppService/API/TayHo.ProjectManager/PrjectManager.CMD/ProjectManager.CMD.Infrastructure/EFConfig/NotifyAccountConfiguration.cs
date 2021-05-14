using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NotifyAccountConfiguration : IEntityTypeConfiguration<NotifyAccount>
    {
        public void Configure(EntityTypeBuilder<NotifyAccount> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NotifyAccount_TABLENAME);
            builder.Property(x => x.AccountId).HasField("_accountId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NotifyId).HasField("_notifyId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PushTime).HasField("_pushTime").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
