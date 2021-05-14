using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_NhomChiPhiConfiguration : IEntityTypeConfiguration<NS_NhomChiPhi>
    {
        public void Configure(EntityTypeBuilder<NS_NhomChiPhi> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_NhomChiPhi_TABLENAME);
	builder.Property(x => x.TenNhomChiPhi).HasField("_tenNhomChiPhi").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.DienGiai).HasField("_dienGiai").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.SortIndex).HasField("_sortIndex").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
