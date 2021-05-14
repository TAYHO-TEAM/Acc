using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class ProjectsConfiguration : IEntityTypeConfiguration<Projects>
    {
        public void Configure(EntityTypeBuilder<Projects> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.Projects_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BarCode).HasField("_barCode").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Descriptions).HasField("_descriptions").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NodeLevel).HasField("_nodeLevel").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.OldId).HasField("_oldId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
