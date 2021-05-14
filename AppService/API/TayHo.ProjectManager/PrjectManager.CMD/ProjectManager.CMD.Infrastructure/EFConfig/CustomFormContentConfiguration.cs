using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class CustomFormContentConfiguration : IEntityTypeConfiguration<CustomFormContent>
    {
        public void Configure(EntityTypeBuilder<CustomFormContent> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.CustomFormContent_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CustomFormId).HasField("_customFormId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
