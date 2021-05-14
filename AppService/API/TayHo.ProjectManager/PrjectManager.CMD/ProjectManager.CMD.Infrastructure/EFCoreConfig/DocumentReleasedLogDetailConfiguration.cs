using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DTOs;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class DocumentReleasedLogDetailConfiguration : IEntityTypeConfiguration<DocumentReleasedLogDetail>
    {
        public void Configure(EntityTypeBuilder<DocumentReleasedLogDetail> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.DocumentReleasedLogDetail_TABLENAME);
        }
    }
}
