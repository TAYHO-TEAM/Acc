using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class ActionsConfiguration : IEntityTypeConfiguration<Actions>
    {
        public void Configure(EntityTypeBuilder<Actions> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.Actions_TABLENAME);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Descriptions).HasField("_descriptions").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Icon).HasField("_icon").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Url).HasField("_url").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CategoryId).HasField("_categoryId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Level).HasField("_level").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasField("_priority").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
