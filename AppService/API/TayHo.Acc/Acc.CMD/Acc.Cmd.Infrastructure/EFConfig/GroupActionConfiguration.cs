using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class GroupActionConfiguration : IEntityTypeConfiguration<GroupAction>
    {
        public void Configure(EntityTypeBuilder<GroupAction> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.GroupAction_TABLENAME);
            builder.Property(x => x.ActionId).HasField("_actionId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
