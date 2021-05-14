using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_ThucChiConfiguration : IEntityTypeConfiguration<NS_ThucChi>
    {
        public void Configure(EntityTypeBuilder<NS_ThucChi> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_ThucChi_TABLENAME);
            builder.Property(x => x.NhomCongViecId).HasField("_nhomCongViecId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GoiThauId).HasField("_goiThauId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ThangBaoCao).HasField("_thangBaoCao").HasMaxLength(100).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ThangThucChi).HasField("_thangThucChi").HasMaxLength(100).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
