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
       
        /// <summary>
        /// View Table
        /// </summary>
        public DbSet<FilesAttachment> FilesAttachment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
