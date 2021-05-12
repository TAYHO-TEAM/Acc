using MediatR;
using Microsoft.EntityFrameworkCore;
using OperationManager.CRUD.DAL.DTO;
using Services.Common.APIs.Cmd.EF;
using System.Reflection;

namespace OperationManager.CRUD.DAL.DBContext
{
    public class QuanLyVanHanhContext: BaseDbContext
    {
        public QuanLyVanHanhContext(DbContextOptions<QuanLyVanHanhContext> options, IMediator mediator) : base(options, mediator)
        {
        }
        public DbSet<DocumentReleased> DocumentReleased { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
