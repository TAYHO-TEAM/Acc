using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class ProblemCategoryConfiguration : IEntityTypeConfiguration<ProblemCategory>
    {
        public void Configure(EntityTypeBuilder<ProblemCategory> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.ProblemCategory_TABLENAME);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Descriptions).HasField("_descriptions").HasMaxLength(2048).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priotity).HasField("_priotity").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
