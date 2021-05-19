using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class DefectiveConfiguration
    {
        public void Configure(EntityTypeBuilder<Defective> builder)
        {
           builder.Property(x => x.ItemsId).HasColumnName("ItemsId").UsePropertyAccessMode(PropertyAccessMode.Field);
	builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(1028).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Description).HasColumnName("Description").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
