using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class ResponseRegistConfiguration : IEntityTypeConfiguration<ResponseRegist>
    {
        public void Configure(EntityTypeBuilder<ResponseRegist> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.ResponseRegist_TABLENAME);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasField("_description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StepProcessId).HasField("_stepProcessId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.RequestRegistId).HasField("_requestRegistId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReplyId).HasField("_replyId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasField("_noAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsApprove).HasField("_isApprove").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TypeOfResult).HasField("_typeOfResult").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
