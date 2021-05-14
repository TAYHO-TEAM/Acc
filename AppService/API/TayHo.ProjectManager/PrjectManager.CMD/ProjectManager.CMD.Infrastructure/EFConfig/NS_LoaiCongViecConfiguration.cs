using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_LoaiCongViecConfiguration : IEntityTypeConfiguration<NS_LoaiCongViec>
    {
        public void Configure(EntityTypeBuilder<NS_LoaiCongViec> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_LoaiCongViec_TABLENAME);
	builder.Property(x => x.TenLoaiCongViec).HasField("_tenLoaiCongViec").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.DienGiai).HasField("_dienGiai").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.KyHieu).HasField("_kyHieu").HasMaxLength(50).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.SortIndex).HasField("_sortIndex").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
