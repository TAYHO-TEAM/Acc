using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class GroupsConfiguration : IEntityTypeConfiguration<Groups>
    {
        public void Configure(EntityTypeBuilder<Groups> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.Groups_TABLENAME);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Descriptions).HasField("_descriptions").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasField("_type").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
