using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class PlanScheduleConfiguration : IEntityTypeConfiguration<PlanSchedule>
    {
        public void Configure(EntityTypeBuilder<PlanSchedule> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.PlanSchedule_TABLENAME);
            builder.Property(x => x.PlanMasterId).HasField("_planMasterId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PlanJobId).HasField("_planJobId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasField("_note").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Remind).HasField("_remind").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Repead).HasField("_repead").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.RepeadType).HasField("_repeadType").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartDate).HasField("_startDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndDate).HasField("_endDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ModifyTimes).HasField("_modifyTimes").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
