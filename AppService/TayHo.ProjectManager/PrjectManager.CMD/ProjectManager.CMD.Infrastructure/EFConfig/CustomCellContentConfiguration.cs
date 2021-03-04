using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class CustomCellContentConfiguration : IEntityTypeConfiguration<CustomCellContent>
    {
        public void Configure(EntityTypeBuilder<CustomCellContent> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.CustomCellContent_TABLENAME);
            builder.Property(x => x.CustomFormBodyId).HasField("_customFormBodyId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CustomFormContentId).HasField("_customFormContentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CustomColumId).HasField("_customColumId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Contents).HasField("_contents").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoRown).HasField("_noRown").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
