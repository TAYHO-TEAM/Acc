using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class OperationProcessConfiguration : IEntityTypeConfiguration<OperationProcess>
    {
        public void Configure(EntityTypeBuilder<OperationProcess> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.OperationProcess_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BarCode).HasField("_barCode").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasField("_description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasField("_priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Level).HasField("_level").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PreviousId).HasField("_previousId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NextId).HasField("_nextId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
