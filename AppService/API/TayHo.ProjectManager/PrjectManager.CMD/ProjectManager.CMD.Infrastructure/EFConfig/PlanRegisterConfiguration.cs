using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class PlanRegisterConfiguration : IEntityTypeConfiguration<PlanRegister>
    {
        public void Configure(EntityTypeBuilder<PlanRegister> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.PlanRegister_TABLENAME);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DocumentTypeId).HasField("_documentTypeId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.WorkItemId).HasField("_workItemId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ContractorInfoId).HasField("_contractorInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasField("_description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.RequestDate).HasField("_requestDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ResponseDate).HasField("_responseDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ExpectRequestDate).HasField("_expectRequestDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ExpectResponseDate).HasField("_expectResponseDate").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
