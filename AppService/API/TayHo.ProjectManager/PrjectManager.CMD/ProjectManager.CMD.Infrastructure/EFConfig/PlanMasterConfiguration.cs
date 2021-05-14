using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class PlanMasterConfiguration : IEntityTypeConfiguration<PlanMaster>
    {
        public void Configure(EntityTypeBuilder<PlanMaster> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.PlanMaster_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PlanProjectId).HasField("_planProjectId").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TimeLine).HasField("_timeLine").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasField("_description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasField("_note").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartDate).HasField("_startDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndDate).HasField("_endDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Unit).HasField("_unit").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Amount).HasField("_amount").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReportPeriodicalType).HasField("_reportPeriodicalType").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReportPeriodical).HasField("_reportPeriodical").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReportFrequency).HasField("_reportFrequency").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasField("_priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ImportantLevel).HasField("_importantLevel").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasField("_noAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
