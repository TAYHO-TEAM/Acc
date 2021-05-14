using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_CongViecDetailConfiguration : IEntityTypeConfiguration<NS_CongViecDetail>
    {
        public void Configure(EntityTypeBuilder<NS_CongViecDetail> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_CongViecDetail_TABLENAME);
            builder.Property(x => x.CongViecId).HasField("_congViecId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReasonId).HasField("_reasonId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaiDoanId).HasField("_giaiDoanId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DonGia).HasField("_donGia").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.KhoiLuong).HasField("_khoiLuong").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
