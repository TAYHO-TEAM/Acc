using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class SysTableManagerConfiguration
    {
        public void Configure(EntityTypeBuilder<SysTableManager> builder)
        {
            builder.ToTable(ProjectManagerConstants.SysTableManager_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TableName).HasColumnName("TableName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HeaderCode).HasColumnName("HeaderCode").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsGenCode).HasColumnName("IsGenCode").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsPushNotify).HasColumnName("IsPushNotify").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TypeNotify).HasColumnName("TypeNotify").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.QuerryString).HasColumnName("QuerryString").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StoreProcName).HasColumnName("StoreProcName").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
