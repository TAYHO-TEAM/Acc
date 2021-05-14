using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class StagesConfiguration : IEntityTypeConfiguration<Stages>
    {
        public void Configure(EntityTypeBuilder<Stages> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.Stages_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(32).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Descriptions).HasField("_descriptions").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
