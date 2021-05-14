using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_NhomCongViecDetailConfiguration : IEntityTypeConfiguration<NS_NhomCongViecDetail>
    {
        public void Configure(EntityTypeBuilder<NS_NhomCongViecDetail> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_NhomCongViecDetail_TABLENAME);
	builder.Property(x => x.NhomCongViecId).HasField("_nhomCongViecId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.GiaiDoanId).HasField("_giaiDoanId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.SortIndex).HasField("_sortIndex").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
