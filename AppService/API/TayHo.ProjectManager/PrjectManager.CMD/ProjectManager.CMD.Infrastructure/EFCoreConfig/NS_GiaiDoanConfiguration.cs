using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DTOs;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFCoẻConfig
{
    public class NS_GiaiDoanConfiguration : IEntityTypeConfiguration<NS_GiaiDoan>
    {
        public void Configure(EntityTypeBuilder<NS_GiaiDoan> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_GiaiDoan_TABLENAME);

        }
    }
}
