using Dapper.Common;
using Dapper.Common.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OperationManager.CRUD.BLL.IRepositories;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;
using OperationManager.CRUD.BLL.Repositories;
using OperationManager.CRUD.BLL.Repositories.BaseClasses;
using OperationManager.CRUD.DAL.DTO.BaseClasses;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.BLL.Extensions
{
    public static class QuanLyVanHanhSqlDbExtensions
    {
        public static IServiceCollection AddOperationManagerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerOptions(configuration).AddSqlRepositories();
            return services;
        }
        #region private functions
        private static IServiceCollection AddSqlServerOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DapperDbOptions>(configuration.GetSection("SQLServerOptions"));
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            return services;
        }

        private static IServiceCollection AddSqlRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQuanLyVanHanhRepository<ConstructionCategory>, QuanLyVanHanhRepository<ConstructionCategory>>();
            services.AddScoped<IQuanLyVanHanhRepository<Construction>, QuanLyVanHanhRepository<Construction>>();
            services.AddScoped<IQuanLyVanHanhRepository<Conversation>, QuanLyVanHanhRepository<Conversation>>();
            services.AddScoped<IQuanLyVanHanhRepository<CustomerInfo>, QuanLyVanHanhRepository<CustomerInfo>>();
            services.AddScoped<IQuanLyVanHanhRepository<CustomerRealEstate>, QuanLyVanHanhRepository<CustomerRealEstate>>();
            services.AddScoped<IQuanLyVanHanhRepository<DefectAcceptance>, QuanLyVanHanhRepository<DefectAcceptance>>();
            services.AddScoped<IQuanLyVanHanhRepository<DefectFeedback>, QuanLyVanHanhRepository<DefectFeedback>>();
            services.AddScoped<IQuanLyVanHanhRepository<DefectFix>, QuanLyVanHanhRepository<DefectFix>>();
            services.AddScoped<IQuanLyVanHanhRepository<Defective>, QuanLyVanHanhRepository<Defective>>();
            services.AddScoped<IQuanLyVanHanhRepository<ConstructionItems>, QuanLyVanHanhRepository<ConstructionItems>>();
            services.AddScoped<IQuanLyVanHanhRepository<LogEvent>, QuanLyVanHanhRepository<LogEvent>>();
            services.AddScoped<IQuanLyVanHanhRepository<Project>, QuanLyVanHanhRepository<Project>>();
            services.AddScoped<IQuanLyVanHanhRepository<RealEstate>, QuanLyVanHanhRepository<RealEstate>>();
            services.AddScoped<IQuanLyVanHanhRepository<TestApi>, QuanLyVanHanhRepository<TestApi>>();
            services.AddScoped<IQuanLyVanHanhRepository<FilesAttachment>, QuanLyVanHanhRepository<FilesAttachment>>();
            services.AddScoped<IQuanLyVanHanhRepository<Complaint>, QuanLyVanHanhRepository<Complaint>>();
            services.AddScoped<IQuanLyVanHanhRepository<ComplaintResolve>, QuanLyVanHanhRepository<ComplaintResolve>>();
            services.AddScoped<IQuanLyVanHanhRepository<ComplaintsType>, QuanLyVanHanhRepository<ComplaintsType>>();
            services.AddScoped<IQuanLyVanHanhRepository<CategoryGoods>, QuanLyVanHanhRepository<CategoryGoods>>();
            services.AddScoped<IQuanLyVanHanhRepository<CategoryStorage>, QuanLyVanHanhRepository<CategoryStorage>>();
            services.AddScoped<IQuanLyVanHanhRepository<MaintenanceLog>, QuanLyVanHanhRepository<MaintenanceLog>>();
            services.AddScoped<IQuanLyVanHanhRepository<MaintenanceSchedule>, QuanLyVanHanhRepository<MaintenanceSchedule>>();
            services.AddScoped<IQuanLyVanHanhRepository<MaintenancerInfo>, QuanLyVanHanhRepository<MaintenancerInfo>>();
            services.AddScoped<IQuanLyVanHanhRepository<MaintenanceSupplierInfo>, QuanLyVanHanhRepository<MaintenanceSupplierInfo>>();
            services.AddScoped<IQuanLyVanHanhRepository<WarehouseGoodsLog>, QuanLyVanHanhRepository<WarehouseGoodsLog>>();
            services.AddScoped<IQuanLyVanHanhRepository<WarehouseGoodsStorage>, QuanLyVanHanhRepository<WarehouseGoodsStorage>>();
            services.AddScoped<IQuanLyVanHanhRepository<WarehouseStorage>, QuanLyVanHanhRepository<WarehouseStorage>>();
            services.AddScoped<IQuanLyVanHanhRepository<CategoryUnit>, QuanLyVanHanhRepository<CategoryUnit>>();
            services.AddScoped<IQuanLyVanHanhRepository<WareHouseAllGoods>, QuanLyVanHanhRepository<WareHouseAllGoods>>();
            services.AddScoped<IQuanLyVanHanhRepository<ComplaintDetail>, QuanLyVanHanhRepository<ComplaintDetail>>();
            services.AddScoped<IQuanLyVanHanhRepository<DefectFeedbackDetail>, QuanLyVanHanhRepository<DefectFeedbackDetail>>();
            services.AddScoped<IQuanLyVanHanhRepository<WarehouseReleased>, QuanLyVanHanhRepository<WarehouseReleased>>();
            services.AddScoped<IQuanLyVanHanhRepository<WarehouseReleasedDetail>, QuanLyVanHanhRepository<WarehouseReleasedDetail>>();
            services.AddScoped<IQuanLyVanHanhRepository<DOBase>, QuanLyVanHanhRepository<DOBase>>();
            services.AddScoped<IQuanLyVanHanhRepository<HandOverItem>, QuanLyVanHanhRepository<HandOverItem>>();
            services.AddScoped<IQuanLyVanHanhRepository<HandOverItemSpecifications>, QuanLyVanHanhRepository<HandOverItemSpecifications>>();
            services.AddScoped<IQuanLyVanHanhRepository<HandOverReceipt>, QuanLyVanHanhRepository<HandOverReceipt>>();
            services.AddScoped<IQuanLyVanHanhRepository<HandOverReceiptDetail>, QuanLyVanHanhRepository<HandOverReceiptDetail>>();
            services.AddScoped<IQuanLyVanHanhRepository<HandOverDelegate>, QuanLyVanHanhRepository<HandOverDelegate>>();
            services.AddScoped<IQuanLyVanHanhRepository<ListOfLocation>, QuanLyVanHanhRepository<ListOfLocation>>();

            services.AddScoped<IReportRepository,ReportRepository>();
            services.AddScoped<ISysJobWithAccountRepository, SysJobWithAccountRepository>();
            services.AddScoped<IComplaintRepository<Complaint>, ComplaintRepository<Complaint>>();

            return services;
        }
        #endregion private functions
    }
}
