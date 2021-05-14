using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_NghiemThuConfiguration : IEntityTypeConfiguration<NS_NghiemThu>
    {
        public void Configure(EntityTypeBuilder<NS_NghiemThu> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_NghiemThu_TABLENAME);
            builder.Property(x => x.CongViecDetailId).HasField("_congViecDetailId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GoiThauId).HasField("_goiThauId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaiDoanId).HasField("_giaiDoanId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Dot).HasField("_dot").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.KhoiLuong).HasField("_khoiLuong").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
