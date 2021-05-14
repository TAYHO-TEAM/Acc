using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class RequestDetailConfiguration : IEntityTypeConfiguration<RequestDetail>
    {
        public void Configure(EntityTypeBuilder<RequestDetail> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.RequestDetail_TABLENAME);
            builder.Property(x => x.RequestId).HasField("_requestId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ProblemCategoryId).HasField("_problemCategoryId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReplyByID).HasField("_replyByID").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Descriptions).HasField("_descriptions").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasField("_note").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DurationDate).HasField("_durationDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StatusText).HasField("_statusText").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FromDate).HasField("_fromDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ToDate).HasField("_toDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasField("_noAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
