using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class DocumentReleasedLogConfiguration : IEntityTypeConfiguration<DocumentReleasedLog>
    {
        public void Configure(EntityTypeBuilder<DocumentReleasedLog> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.DocumentReleasedLog_TABLENAME);
            builder.Property(x => x.AccountId).HasField("_accountId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DocumentReleasedId).HasField("_documentReleasedId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasField("_note").HasMaxLength(50).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
