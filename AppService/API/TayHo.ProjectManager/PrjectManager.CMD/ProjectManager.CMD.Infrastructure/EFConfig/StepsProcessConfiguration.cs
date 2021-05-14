using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class StepsProcessConfiguration : IEntityTypeConfiguration<StepsProcess>
    {
        public void Configure(EntityTypeBuilder<StepsProcess> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.StepsProcess_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasField("_priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Level).HasField("_level").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PreviousId).HasField("_previousId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NextId).HasField("_nextId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.OperationProcessId).HasField("_operationProcessId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
