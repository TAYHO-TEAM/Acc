using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class DefectAcceptanceConfiguration
    {
        public void Configure(EntityTypeBuilder<DefectAcceptance> builder)
        {
           builder.Property(x => x.DefectFixId).HasColumnName("DefectFixId").UsePropertyAccessMode(PropertyAccessMode.Field);
	builder.Property(x => x.CustomerInfoId).HasColumnName("CustomerInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Note).HasColumnName("Note").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
