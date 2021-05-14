using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class CustomFormBodyConfiguration : IEntityTypeConfiguration<CustomFormBody>
    {
        public void Configure(EntityTypeBuilder<CustomFormBody> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.CustomFormBody_TABLENAME);
            builder.Property(x => x.Header).HasField("_header").HasMaxLength(1028).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CustomTableId).HasField("_customTableId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CustomFormId).HasField("_customFormId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasField("_priority").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
