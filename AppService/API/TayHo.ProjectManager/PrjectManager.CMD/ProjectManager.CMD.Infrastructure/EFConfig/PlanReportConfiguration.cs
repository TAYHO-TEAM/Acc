using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class PlanReportConfiguration : IEntityTypeConfiguration<PlanReport>
    {
        public void Configure(EntityTypeBuilder<PlanReport> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.PlanReport_TABLENAME);
            builder.Property(x => x.PlanMasterId).HasField("_planMasterId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PlanJobId).HasField("_planJobId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Content).HasField("_content").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Unit).HasField("_unit").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Amount).HasField("_amount").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
