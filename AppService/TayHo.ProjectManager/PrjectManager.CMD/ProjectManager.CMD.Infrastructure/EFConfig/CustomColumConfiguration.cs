using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class CustomColumConfiguration : IEntityTypeConfiguration<CustomColum>
    {
        public void Configure(EntityTypeBuilder<CustomColum> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.CustomColum_TABLENAME);
            builder.Property(x => x.CustomTableId).HasField("_customTableId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ColIndex).HasField("_colIndex").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Header).HasField("_header").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TypeParam).HasField("_typeParam").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Style).HasField("_style").HasMaxLength(1028).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SourceValue).HasField("_sourceValue").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SourceLink).HasField("_sourceLink").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
