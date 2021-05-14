using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class CategorysConfiguration : IEntityTypeConfiguration<Categorys>
    {
        public void Configure(EntityTypeBuilder<Categorys> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.Categorys_TABLENAME);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Descriptions).HasField("_descriptions").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
