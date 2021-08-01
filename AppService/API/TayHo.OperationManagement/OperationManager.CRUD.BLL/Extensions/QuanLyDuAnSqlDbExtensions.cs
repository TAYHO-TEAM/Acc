using Dapper.Common;
using Dapper.Common.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;
using OperationManager.CRUD.BLL.Repositories.BaseClasses;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.BLL.Extensions
{
    public static class QuanLyDuAnSqlDbExtensions
    {
        public static IServiceCollection AddProjectManagerServices(this IServiceCollection services, IConfiguration configuration)
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
            services.AddScoped<IQuanLyDuAnRepository<FilesAttachment>, QuanLyDuAnRepository<FilesAttachment>>();
            services.AddScoped<IQuanLyDuAnRepository<SysAutoSendMail>, QuanLyDuAnRepository<SysAutoSendMail>>();
            services.AddScoped<IQuanLyDuAnRepository<SysJob>, QuanLyDuAnRepository<SysJob>>();
            services.AddScoped<IQuanLyDuAnRepository<SysJobColum>, QuanLyDuAnRepository<SysJobColum>>();
            services.AddScoped<IQuanLyDuAnRepository<SysJobGroups>, QuanLyDuAnRepository<SysJobGroups>>();
            services.AddScoped<IQuanLyDuAnRepository<SysJobParameter>, QuanLyDuAnRepository<SysJobParameter>>();
            services.AddScoped<IQuanLyDuAnRepository<SysJobTable>, QuanLyDuAnRepository<SysJobTable>>();
            services.AddScoped<IQuanLyDuAnRepository<SysMailAccount>, QuanLyDuAnRepository<SysMailAccount>>();
            services.AddScoped<IQuanLyDuAnRepository<SysSetting>, QuanLyDuAnRepository<SysSetting>>();
            services.AddScoped<IQuanLyDuAnRepository<SysTableManager>, QuanLyDuAnRepository<SysTableManager>>();
            services.AddScoped<IQuanLyDuAnRepository<SysTemplateReport>, QuanLyDuAnRepository<SysTemplateReport>>();

            return services;
        }
        #endregion private functions
    }
}
