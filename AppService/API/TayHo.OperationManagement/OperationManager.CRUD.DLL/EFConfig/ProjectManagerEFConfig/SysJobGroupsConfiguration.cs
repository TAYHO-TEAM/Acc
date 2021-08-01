using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class SysJobGroupsConfiguration
    {
        public void Configure(EntityTypeBuilder<SysJobGroups> builder)
        {
            builder.ToTable(ProjectManagerConstants.SysJobGroups_TABLENAME);
           builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
	builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.GroupsId).HasColumnName("GroupsId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.SysJobId).HasColumnName("SysJobId").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
