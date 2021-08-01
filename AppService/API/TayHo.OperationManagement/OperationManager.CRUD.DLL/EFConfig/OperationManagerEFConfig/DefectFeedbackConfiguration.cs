using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class DefectFeedbackConfiguration
    {
        public void Configure(EntityTypeBuilder<DefectFeedback> builder)
        {
            builder.ToTable(OperationManagerConstants.DefectFeedback_TABLENAME);
            builder.Property(x => x.RealEstateId).HasColumnName("RealEstateId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CustomerId).HasColumnName("CustomerId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DefectiveId).HasColumnName("DefectiveId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ConstructionItemsId).HasColumnName("ConstructionItemsId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Phone).HasColumnName("Phone").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FullName).HasColumnName("FullName").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasColumnName("Note").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
