using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class ComplaintConfiguration
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.ToTable(OperationManagerConstants.Complaint_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ComplaintTypeId).HasColumnName("ComplaintTypeId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CustomerInfoId).HasColumnName("CustomerInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ConstructionItemsId).HasColumnName("ConstructionItemsId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.RealEstateId).HasColumnName("RealEstateId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FullName).HasColumnName("FullName").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Phone).HasColumnName("Phone").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasColumnName("Note").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ComplaintDate).HasColumnName("ComplaintDate").HasColumnType("datetime").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
