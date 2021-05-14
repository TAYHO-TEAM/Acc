using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class WorkItemsConfiguration : IEntityTypeConfiguration<WorkItems>
    {
        public void Configure(EntityTypeBuilder<WorkItems> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.WorkItems_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BarCode).HasField("_barCode").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasField("_description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.level).HasField("_level").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
