using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_KhauTru_TheoDoiConfiguration : IEntityTypeConfiguration<NS_KhauTru_TheoDoi>
    {
        public void Configure(EntityTypeBuilder<NS_KhauTru_TheoDoi> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_KhauTru_TheoDoi_TABLENAME);
            builder.Property(x => x.KhauTruId).HasField("_khauTruId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoiDung).HasField("_noiDung").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Dot).HasField("_dot").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
