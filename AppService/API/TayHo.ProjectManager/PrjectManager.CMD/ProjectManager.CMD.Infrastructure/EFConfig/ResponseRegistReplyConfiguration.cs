using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class ResponseRegistReplyConfiguration : IEntityTypeConfiguration<ResponseRegistReply>
    {
        public void Configure(EntityTypeBuilder<ResponseRegistReply> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.ResponseRegistReply_TABLENAME);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasField("_description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReplyAccountId).HasField("_replyAccountId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ResponseRegitId).HasField("_responseRegitId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasField("_noAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
