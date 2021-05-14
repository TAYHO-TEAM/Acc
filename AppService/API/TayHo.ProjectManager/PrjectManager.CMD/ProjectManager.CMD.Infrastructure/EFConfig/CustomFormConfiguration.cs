using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class CustomFormConfiguration : IEntityTypeConfiguration<CustomForm>
    {
        public void Configure(EntityTypeBuilder<CustomForm> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.CustomForm_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Header).HasField("_header").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Style).HasField("_style").HasMaxLength(1028).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
