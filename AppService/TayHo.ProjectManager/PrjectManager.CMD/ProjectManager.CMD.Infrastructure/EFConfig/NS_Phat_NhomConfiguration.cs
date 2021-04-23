using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_Phat_NhomConfiguration : IEntityTypeConfiguration<NS_Phat_Nhom>
    {
        public void Configure(EntityTypeBuilder<NS_Phat_Nhom> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_Phat_Nhom_TABLENAME);
	builder.Property(x => x.TenNhomPhat).HasField("_tenNhomPhat").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.SortIndex).HasField("_sortIndex").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
