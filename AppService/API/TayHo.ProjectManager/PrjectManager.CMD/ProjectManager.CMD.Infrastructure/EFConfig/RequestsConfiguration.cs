using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class RequestsConfiguration : IEntityTypeConfiguration<Requests>
    {
        public void Configure(EntityTypeBuilder<Requests> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.Requests_TABLENAME);
            builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(32).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.RequestFromId).HasField("_requestFromId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StageId).HasField("_stageId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasField("_priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReplyById).HasField("_replyById").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SendDateTime).HasField("_sendDateTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasField("_noAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
