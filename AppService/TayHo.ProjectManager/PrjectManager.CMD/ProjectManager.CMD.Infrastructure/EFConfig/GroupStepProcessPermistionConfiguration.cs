using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class GroupStepProcessPermistionConfiguration : IEntityTypeConfiguration<GroupStepProcessPermistion>
    {
        public void Configure(EntityTypeBuilder<GroupStepProcessPermistion> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.GroupStepProcessPermistion_TABLENAME);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StepProcessId).HasField("_stepProcessId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Permistion).HasField("_permistion").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
