using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class GroupFunctionPermistionConfiguration : IEntityTypeConfiguration<GroupFunctionPermistion>
    {
        public void Configure(EntityTypeBuilder<GroupFunctionPermistion> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.GroupFunctionPermistion_TABLENAME);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FunctionId).HasField("_functionId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PermistionId).HasField("_permistionId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
