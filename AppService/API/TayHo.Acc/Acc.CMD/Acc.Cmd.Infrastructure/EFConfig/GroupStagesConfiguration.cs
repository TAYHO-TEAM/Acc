using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class GroupStagesConfiguration : IEntityTypeConfiguration<GroupStages>
    {
        public void Configure(EntityTypeBuilder<GroupStages> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.GroupStages_TABLENAME);
            builder.Property(x => x.StageId).HasField("_stageId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
