using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_GoiThauConfiguration : IEntityTypeConfiguration<NS_GoiThau>
    {
        public void Configure(EntityTypeBuilder<NS_GoiThau> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_GoiThau_TABLENAME);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SoHopDong).HasField("_soHopDong").HasMaxLength(50).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ContractorInfoId).HasField("_contractorInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NgayKy).HasField("_ngayKy").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ThoiGianBaoHanh).HasField("_thoiGianBaoHanh").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ThoiGianGiuBaoHanh).HasField("_thoiGianGiuBaoHanh").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TyLeTamUng).HasField("_tyLeTamUng").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TyLeGiuLai).HasField("_tyLeGiuLai").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TyLeThanhToanToiDa).HasField("_tyLeThanhToanToiDa").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
