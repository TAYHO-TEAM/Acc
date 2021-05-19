using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class CustomerInfoConfiguration
    {
        public void Configure(EntityTypeBuilder<CustomerInfo> builder)
        {
            builder.ToTable(OperationManagerConstants.CustomerInfo_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BarCode).HasColumnName("BarCode").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Birthday).HasColumnName("Birthday").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Phone).HasColumnName("Phone").HasMaxLength(16).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(16).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Sex).HasColumnName("Sex").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IDCard).HasColumnName("IDCard").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
