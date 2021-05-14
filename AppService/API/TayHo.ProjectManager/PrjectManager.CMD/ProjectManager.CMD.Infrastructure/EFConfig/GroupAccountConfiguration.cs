using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
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
