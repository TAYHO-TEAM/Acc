using Acc.Cmd.Api.Application.Behaviors;
using Acc.Cmd.Domain.Repositories;
using Acc.Cmd.Domain.Services;
using Acc.Cmd.Infrastructure.Repositories;
using Acc.Cmd.Infrastructure.Services;
using Autofac;
using MediatR;

namespace Acc.Cmd.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register services
            builder.RegisterGeneric(typeof(LoggingBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPerformanceBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<TokenManager>().As<ITokenManager>().InstancePerLifetimeScope();
            builder.RegisterType<MediaService>().As<IMediaService>().InstancePerLifetimeScope();
            //builder.RegisterType<UserBlackListCacheManager>().As<IUserBlackListCacheManager>().InstancePerLifetimeScope();
            // register repositories
            builder.RegisterType<AccountsRepository>().As<IAccountsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserInfoRepository>().As<IUserInfoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ActionsRepository>().As<IActionsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategorysRepository>().As<ICategorysRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ContractorInfoRepository>().As<IContractorInfoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DeviceAccountRepository>().As<IDeviceAccountRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentTypeRepository>().As<IDocumentTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FunctionsRepository>().As<IFunctionsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupAccountRepository>().As<IGroupAccountRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupActionRepository>().As<IGroupActionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupActionPermistionRepository>().As<IGroupActionPermistionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupFunctionPermistionRepository>().As<IGroupFunctionPermistionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupPermistionRepository>().As<IGroupPermistionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupsRepository>().As<IGroupsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupStagesRepository>().As<IGroupStagesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PermistionsRepository>().As<IPermistionsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProjectsRepository>().As<IProjectsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RelationTableRepository>().As<IRelationTableRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StaffTayHoRepository>().As<IStaffTayHoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StepsProcessRepository>().As<IStepsProcessRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupStepProcessPermistionRepository>().As<IGroupStepProcessPermistionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<WorkItemsRepository>().As<IWorkItemsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LogEventRepository>().As<ILogEventRepository>().InstancePerLifetimeScope();
        }
    }
}
