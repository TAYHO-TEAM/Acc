using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NotifyTemplateConfiguration : IEntityTypeConfiguration<NotifyTemplate>
    {
        public void Configure(EntityTypeBuilder<NotifyTemplate> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NotifyTemplate_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Content).HasField("_content").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
