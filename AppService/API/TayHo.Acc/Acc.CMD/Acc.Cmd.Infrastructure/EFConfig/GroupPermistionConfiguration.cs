using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class GroupPermistionConfiguration : IEntityTypeConfiguration<GroupPermistion>
    {
        public void Configure(EntityTypeBuilder<GroupPermistion> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.GroupPermistion_TABLENAME);
            builder.Property(x => x.PermistionId).HasField("_permistionId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
