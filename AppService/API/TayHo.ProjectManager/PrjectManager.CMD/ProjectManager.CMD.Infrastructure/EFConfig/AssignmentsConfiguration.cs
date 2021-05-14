using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class AssignmentsConfiguration : IEntityTypeConfiguration<Assignments>
    {
        public void Configure(EntityTypeBuilder<Assignments> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.Assignments_TABLENAME);
            builder.Property(x => x.AccountId).HasField("_accountId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.RequestId).HasField("_requestId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.RequestDetailId).HasField("_requestDetailId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
