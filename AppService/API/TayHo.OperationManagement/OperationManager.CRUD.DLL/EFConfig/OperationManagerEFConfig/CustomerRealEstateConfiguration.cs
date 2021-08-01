using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class CustomerRealEstateConfiguration
    {
        public void Configure(EntityTypeBuilder<CustomerRealEstate> builder)
        {
            builder.ToTable(OperationManagerConstants.CustomerRealEstate_TABLENAME);
            builder.Property(x => x.RealEstateId).HasColumnName("RealEstateId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CustomerInfoId).HasColumnName("CustomerInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.OwnerType).HasColumnName("OwnerType").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
