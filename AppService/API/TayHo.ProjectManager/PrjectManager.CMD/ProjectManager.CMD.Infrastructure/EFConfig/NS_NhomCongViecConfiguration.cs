using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_NhomCongViecConfiguration : IEntityTypeConfiguration<NS_NhomCongViec>
    {
        public void Configure(EntityTypeBuilder<NS_NhomCongViec> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_NhomCongViec_TABLENAME);
	builder.Property(x => x.HangMucId).HasField("_hangMucId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.LoaiCongViecId).HasField("_loaiCongViecId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.GoiThauId).HasField("_goiThauId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.NhomChiPhiId).HasField("_nhomChiPhiId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.TenNhomCongViec).HasField("_tenNhomCongViec").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.SortIndex).HasField("_sortIndex").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
