using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class SysMailAccountConfiguration : IEntityTypeConfiguration<SysMailAccount>
    {
        public void Configure(EntityTypeBuilder<SysMailAccount> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.SysMailAccount_TABLENAME);
            builder.Property(x => x.SysAutoSendMailId).HasField("_sysAutoSendMailId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Email).HasField("_email").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasField("_type").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
