using ProjectManager.CMD.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NotifyConfiguration : IEntityTypeConfiguration<Notify>
    {
        public void Configure(EntityTypeBuilder<Notify> builder)
        {

            builder.ToTable(QuanLyDuAnConstants.Notify_TABLENAME);
            builder.Property(x => x.Type).HasField("_type").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Category).HasField("_category").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Message).HasField("_message").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Link).HasField("_link").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TemplateId).HasField("_templateId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Sub).HasField("_sub").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BodyContent).HasField("_bodyContent").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
