using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class GroupActionPermistionConfiguration : IEntityTypeConfiguration<GroupActionPermistion>
    {
        public void Configure(EntityTypeBuilder<GroupActionPermistion> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.GroupActionPermistion_TABLENAME);
            builder.Property(x => x.PermistionId).HasField("_permistionId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ActionId).HasField("_actionId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
