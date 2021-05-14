using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.Reply_TABLENAME);
            builder.Property(x => x.RequestDetailId).HasField("_requestDetailId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasField("_noAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Content).HasField("_content").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
