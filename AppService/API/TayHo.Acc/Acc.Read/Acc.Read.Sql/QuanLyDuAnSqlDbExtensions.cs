using Acc.Read.Sql.DTOs;
using Acc.Read.Sql.Interfaces;
using Acc.Read.Sql.Repositories;
using Dapper.Common;
using Dapper.Common.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acc.Read.Sql
{
    public static class QuanLyDuAnSqlDbExtensions
    {
        public static IServiceCollection AddQuanLyDuAnServices(this IServiceCollection services, IConfiguration configuration)
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
            services.AddScoped<IActionsRepository<ActionsDTOCC>, ActionsRepository<ActionsDTOCC>>();
            services.AddScoped<IDOBaseRepository<ActionsDTO>, DOBaseRepository<ActionsDTO>>();
            services.AddScoped<IDOBaseRepository<AccountsDTO>, DOBaseRepository<AccountsDTO>>();
            services.AddScoped<IDOBaseRepository<CategorysDTO>, DOBaseRepository<CategorysDTO>>();
            services.AddScoped<IDOBaseRepository<ContractorInfoDTO>, DOBaseRepository<ContractorInfoDTO>>();
            services.AddScoped<IDOBaseRepository<DeviceAccountDTO>, DOBaseRepository<DeviceAccountDTO>>();
            services.AddScoped<IDOBaseRepository<FunctionsDTO>, DOBaseRepository<FunctionsDTO>>();
            services.AddScoped<IDOBaseRepository<GroupAccountDTO>, DOBaseRepository<GroupAccountDTO>>();
            services.AddScoped<IDOBaseRepository<GroupActionDTO>, DOBaseRepository<GroupActionDTO>>();
            services.AddScoped<IDOBaseRepository<GroupFunctionPermistionDTO>, DOBaseRepository<GroupFunctionPermistionDTO>>();
            services.AddScoped<IDOBaseRepository<GroupPermistionDTO>, DOBaseRepository<GroupPermistionDTO>>();
            services.AddScoped<IDOBaseRepository<GroupActionPermistionDTO>, DOBaseRepository<GroupActionPermistionDTO>>();
            services.AddScoped<IDOBaseRepository<GroupsDTO>, DOBaseRepository<GroupsDTO>>();
            services.AddScoped<IDOBaseRepository<LogEventDTO>, DOBaseRepository<LogEventDTO>>();
            services.AddScoped<IDOBaseRepository<PermistionsDTO>, DOBaseRepository<PermistionsDTO>>();
            services.AddScoped<IDOBaseRepository<ProjectsDTO>, DOBaseRepository<ProjectsDTO>>();
            services.AddScoped<IDOBaseRepository<RelationTableDTO>, DOBaseRepository<RelationTableDTO>>();
            services.AddScoped<IDOBaseRepository<UserInfoDTO>, DOBaseRepository<UserInfoDTO>>();
            services.AddScoped<IDOBaseRepository<WorkItemsDTO>, DOBaseRepository<WorkItemsDTO>>();
            services.AddScoped<IDOBaseRepository<GroupStepProcessPermistionDTO>, DOBaseRepository<GroupStepProcessPermistionDTO>>();
            services.AddScoped<IDOBaseRepository<OperationProcessDTO>, DOBaseRepository<OperationProcessDTO>>();
            return services;
        }

        #endregion private functions
    }
}
