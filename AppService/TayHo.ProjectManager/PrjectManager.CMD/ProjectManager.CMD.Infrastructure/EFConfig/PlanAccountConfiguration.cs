using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class PlanAccountConfiguration : IEntityTypeConfiguration<PlanAccount>
    {
        public void Configure(EntityTypeBuilder<PlanAccount> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.PlanAccount_TABLENAME);
            builder.Property(x => x.AccountId).HasField("_accountId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PermistionId).HasField("_permistionId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.OwnerById).HasField("_ownerById").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.OwnerTable).HasField("_ownerTable").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
