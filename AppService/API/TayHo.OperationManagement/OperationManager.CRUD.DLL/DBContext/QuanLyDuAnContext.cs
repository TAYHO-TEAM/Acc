using MediatR;
using Microsoft.EntityFrameworkCore;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;
using Services.Common.APIs.Cmd.EF;
using System.Reflection;

namespace OperationManager.CRUD.DAL.DBContext
{
    public class QuanLyDuAnContext : BaseDbContext
    {
        public QuanLyDuAnContext(DbContextOptions<QuanLyDuAnContext> options, IMediator mediator) : base(options, mediator)
        {
        }
       
      
        public DbSet<FilesAttachment> FilesAttachment { get; set; }
        public DbSet<SysAutoSendMail> SysAutoSendMail { get; set; }
        public DbSet<SysJob> SysJob { get; set; }
        public DbSet<SysJobColum> SysJobColum { get; set; }
        public DbSet<SysJobGroups> SysJobGroups { get; set; }
        public DbSet<SysJobParameter> SysJobParameter { get; set; }
        public DbSet<SysJobTable> SysJobTable { get; set; }
        public DbSet<SysMailAccount> SysMailAccount { get; set; }
        public DbSet<SysSetting> SysSetting { get; set; }
        public DbSet<SysTableManager> SysTableManager { get; set; }
        public DbSet<SysTemplateReport> SysTemplateReport { get; set; }

        /// <summary>
        /// View Table
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
