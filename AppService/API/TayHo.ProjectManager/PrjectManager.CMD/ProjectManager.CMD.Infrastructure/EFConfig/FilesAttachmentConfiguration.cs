using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class FilesAttachmentConfiguration : IEntityTypeConfiguration<FilesAttachment>
    {
        public void Configure(EntityTypeBuilder<FilesAttachment> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.FilesAttachment_TABLENAME);
            builder.Property(x => x.OwnerById).HasField("_ownerById").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.OwnerByTable).HasField("_ownerByTable").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(32).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FileName).HasField("_fileName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DisplayName).HasField("_displayName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Tail).HasField("_tail").HasMaxLength(10).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Url).HasField("_url").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Host).HasField("_host").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasField("_type").HasMaxLength(10).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Direct).HasField("_direct").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
