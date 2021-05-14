using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class DocumentReleasedAccountConfiguration : IEntityTypeConfiguration<DocumentReleasedAccount>
    {
        public void Configure(EntityTypeBuilder<DocumentReleasedAccount> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.DocumentReleasedAccount_TABLENAME);
            builder.Property(x => x.AccountId).HasField("_accountId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DocumentReleasedId).HasField("_documentReleasedId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
