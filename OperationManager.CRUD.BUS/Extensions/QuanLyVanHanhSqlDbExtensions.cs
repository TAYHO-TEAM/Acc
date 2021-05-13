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
            services.AddScoped<IQuanLyVanHanhRepository<TestApi>, QuanLyVanHanhRepository<TestApi>>();
            return services;
        }
        #endregion private functions
    }
}
