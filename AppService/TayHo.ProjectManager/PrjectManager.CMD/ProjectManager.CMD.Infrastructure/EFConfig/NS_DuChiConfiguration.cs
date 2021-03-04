using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_DuChiConfiguration : IEntityTypeConfiguration<NS_DuChi>
    {
        public void Configure(EntityTypeBuilder<NS_DuChi> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_DuChi_TABLENAME);
            builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NhomCongViecId).HasField("_nhomCongViecId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ThoiGianBaoCao).HasField("_thoiGianBaoCao").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ThoiGianDuChi).HasField("_thoiGianDuChi").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
