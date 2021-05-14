using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_GiaiDoanConfiguration : IEntityTypeConfiguration<NS_GiaiDoan>
    {
        public void Configure(EntityTypeBuilder<NS_GiaiDoan> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_GiaiDoan_TABLENAME);
	builder.Property(x => x.TenGiaiDoan).HasField("_tenGiaiDoan").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.DienGiai).HasField("_dienGiai").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.CapDo).HasField("_capDo").HasMaxLength(10).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.SortIndex).HasField("_sortIndex").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
