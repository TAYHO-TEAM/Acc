using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class TemplateMailConfiguration : IEntityTypeConfiguration<TemplateMail>
    {
        public void Configure(EntityTypeBuilder<TemplateMail> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.TemplateMail_TABLENAME);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BodyContent).HasField("_bodyContent").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsBodyHtml).HasField("_isBodyHtml").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
