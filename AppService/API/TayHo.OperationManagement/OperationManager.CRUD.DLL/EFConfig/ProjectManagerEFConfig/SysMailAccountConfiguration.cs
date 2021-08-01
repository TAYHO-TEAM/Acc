using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class SysMailAccountConfiguration
    {
        public void Configure(EntityTypeBuilder<SysMailAccount> builder)
        {
            builder.ToTable(ProjectManagerConstants.SysMailAccount_TABLENAME);
            builder.Property(x => x.SysAutoSendMailId).HasColumnName("SysAutoSendMailId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
