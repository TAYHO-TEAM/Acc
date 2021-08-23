using MediatR;
using Microsoft.EntityFrameworkCore;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;
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
        public DbSet<ConstructionItems> ConstructionItems { get; set; }
        public DbSet<LogEvent> LogEvent { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<RealEstate> RealEstate { get; set; }
        public DbSet<FilesAttachment> FilesAttachment { get; set; }
        public DbSet<TestApi> TestApi { get; set; }
        public DbSet<CategoryGoods> CategoryGoods { get; set; }
        public DbSet<CategoryStorage> CategoryStorage { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<ComplaintResolve> ComplaintResolve { get; set; }
        public DbSet<ComplaintsType> ComplaintsType { get; set; }
        public DbSet<MaintenanceLog> MaintenanceLog { get; set; }
        public DbSet<MaintenancerInfo> MaintenancerInfo { get; set; }
        public DbSet<MaintenanceSchedule> MaintenanceSchedule { get; set; }
        public DbSet<MaintenanceSupplierInfo> MaintenanceSupplierInfo { get; set; }
        public DbSet<WarehouseGoodsLog> WarehouseGoodsLog { get; set; }
        public DbSet<WarehouseGoodsStorage> WarehouseGoodsStorage { get; set; }
        public DbSet<WarehouseStorage> WarehouseStorage { get; set; }
        public DbSet<CategoryUnit> CategoryUnit { get; set; }
        public DbSet<ComplaintDetail> ComplaintDetail { get; set; }
        public DbSet<DefectFeedbackDetail> DefectFeedbackDetail { get; set; }
        public DbSet<WarehouseReleased> WarehouseReleased { get; set; }
        public DbSet<WarehouseReleasedDetail> WarehouseReleasedDetail { get; set; }
        public DbSet<SysJobWithAccount> SysJobWithAccount { get; set; }
        public DbSet<HandOverItem> HandOverItem { get; set; }
        public DbSet<HandOverItemSpecifications> HandOverItemSpecifications { get; set; }
        public DbSet<HandOverReceipt> HandOverReceipt { get; set; }
        public DbSet<HandOverReceiptDetail> HandOverReceiptDetail { get; set; }

        /// <summary>
        /// View Table
        /// </summary>
        public DbSet<WareHouseAllGoods> WareHouseAllGoods { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
