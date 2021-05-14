using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class RequestRegistConfiguration : IEntityTypeConfiguration<RequestRegist>
    {
        public void Configure(EntityTypeBuilder<RequestRegist> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.RequestRegist_TABLENAME);
            builder.Property(x => x.PlanRegisterId).HasField("_planRegisterId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BarCode).HasField("_barCode").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Descriptions).HasField("_descriptions").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasField("_note").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Level).HasField("_level").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasField("_noAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.WorkItemId).HasField("_workItemId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DocumentTypeId).HasField("_documentTypeId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Rev).HasField("_rev").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
