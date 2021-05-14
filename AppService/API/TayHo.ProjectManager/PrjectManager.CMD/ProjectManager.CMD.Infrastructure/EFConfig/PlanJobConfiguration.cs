using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class PlanJobConfiguration : IEntityTypeConfiguration<PlanJob>
    {
        public void Configure(EntityTypeBuilder<PlanJob> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.PlanJob_TABLENAME);
            builder.Property(x => x.PlanMasterId).HasField("_planMasterId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasField("_description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Unit).HasField("_unit").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Amount).HasField("_amount").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartDate).HasField("_startDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndDate).HasField("_endDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ModifyTimes).HasField("_modifyTimes").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasField("_priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ImportantLevel).HasField("_importantLevel").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsDone).HasField("_isDone").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
