using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class GroupAccountConfiguration : IEntityTypeConfiguration<GroupAccount>
    {
        public void Configure(EntityTypeBuilder<GroupAccount> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.GroupAccount_TABLENAME);
            builder.Property(x => x.AccountId).HasField("_accountId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
