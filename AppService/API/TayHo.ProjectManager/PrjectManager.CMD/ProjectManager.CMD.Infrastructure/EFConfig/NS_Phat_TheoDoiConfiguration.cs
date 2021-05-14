using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_Phat_TheoDoiConfiguration : IEntityTypeConfiguration<NS_Phat_TheoDoi>
    {
        public void Configure(EntityTypeBuilder<NS_Phat_TheoDoi> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_Phat_TheoDoi_TABLENAME);
            builder.Property(x => x.PhatId).HasField("_phatId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoiDung).HasField("_noiDung").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Dot).HasField("_dot").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
