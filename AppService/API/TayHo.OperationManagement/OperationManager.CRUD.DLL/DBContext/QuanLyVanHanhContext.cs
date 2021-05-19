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
        //public DbSet<DocumentReleased> DocumentReleased { get; set; }
        public DbSet<ConstructionCategory> ConstructionCategory { get; set; }
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<CustomerRealEstate> CustomerRealEstate { get; set; }
        public DbSet<DefectAcceptance> DefectAcceptance { get; set; }
        public DbSet<DefectFeedback> DefectFeedback { get; set; }
        public DbSet<DefectFix> DefectFix { get; set; }
        public DbSet<Defective> Defective { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<LogEvent> LogEvent { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<RealEstate> RealEstate { get; set; }
        public DbSet<TestApi> TestApi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
