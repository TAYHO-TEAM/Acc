using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class RealEstateConfiguration
    {
        public void Configure(EntityTypeBuilder<RealEstate> builder)
        {
            builder.ToTable(OperationManagerConstants.RealEstate_TABLENAME);
            builder.Property(x => x.ConstructionItemsId).HasColumnName("ConstructionItemsId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BarCode).HasColumnName("BarCode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Address).HasColumnName("Address").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Street).HasColumnName("Street").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Ward).HasColumnName("Ward").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.District).HasColumnName("District").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.City).HasColumnName("City").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Country).HasColumnName("Country").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ZipCode).HasColumnName("ZipCode").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
