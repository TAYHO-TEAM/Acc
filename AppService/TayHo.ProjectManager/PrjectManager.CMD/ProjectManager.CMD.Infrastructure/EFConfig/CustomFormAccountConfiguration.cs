using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class CustomFormAccountConfiguration : IEntityTypeConfiguration<CustomFormAccount>
    {
        public void Configure(EntityTypeBuilder<CustomFormAccount> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.CustomFormAccount_TABLENAME);
            builder.Property(x => x.CustomFormId).HasField("_customFormId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.AccountId).HasField("_accountId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
