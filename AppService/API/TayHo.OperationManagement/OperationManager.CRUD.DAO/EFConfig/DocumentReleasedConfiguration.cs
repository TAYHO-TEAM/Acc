using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.DAL.DTO;
using ProjectManager.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class DocumentReleasedConfiguration
    {
        public void Configure(EntityTypeBuilder<DocumentReleased> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.DocumentReleased_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasColumnName("Description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DocumentTypeId).HasColumnName("DocumentTypeId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ProjectId).HasColumnName("ProjectId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.WorkItemId).HasColumnName("WorkItemId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TagWorkItem).HasColumnName("TagWorkItem").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Location).HasColumnName("Location").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Calendar).HasColumnName("Calendar").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
