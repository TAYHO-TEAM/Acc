using Dapper.Common;
using Dapper.Common.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;
using OperationManager.CRUD.BLL.Repositories.BaseClasses;
using OperationManager.CRUD.DAL.DTO;

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
            services.AddScoped<IQuanLyVanHanhRepository<Items>, QuanLyVanHanhRepository<Items>>();
            services.AddScoped<IQuanLyVanHanhRepository<LogEvent>, QuanLyVanHanhRepository<LogEvent>>();
            services.AddScoped<IQuanLyVanHanhRepository<Project>, QuanLyVanHanhRepository<Project>>();
            services.AddScoped<IQuanLyVanHanhRepository<TestApi>, QuanLyVanHanhRepository<TestApi>>();
            return services;
        }
        #endregion private functions
    }
}
