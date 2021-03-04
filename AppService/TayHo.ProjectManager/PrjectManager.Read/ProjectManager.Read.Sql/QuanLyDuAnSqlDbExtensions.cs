using Dapper.Common;
using Dapper.Common.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Repositories;

namespace ProjectManager.Read.Sql
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
            services.AddScoped<IDOBaseRepository<StagesDTO>, DOBaseRepository<StagesDTO>>();
            services.AddScoped<IDOBaseRepository<ActionsDTO>, DOBaseRepository<ActionsDTO>>();
            services.AddScoped<IDOBaseRepository<RequestsDTO>, DOBaseRepository<RequestsDTO>>();
            services.AddScoped<IDOBaseRepository<RequestDetailDTO>, DOBaseRepository<RequestDetailDTO>>();
            services.AddScoped<IDOBaseRepository<ProblemCategoryDTO>, DOBaseRepository<ProblemCategoryDTO>>();
            services.AddScoped<IDOBaseRepository<GroupStagesDTO>, DOBaseRepository<GroupStagesDTO>>();
            services.AddScoped<IDOBaseRepository<FilesAttachmentDTO>, DOBaseRepository<FilesAttachmentDTO>>();
            services.AddScoped<IDOBaseRepository<DocumentTypeDTO>, DOBaseRepository<DocumentTypeDTO>>();
            services.AddScoped<IDOBaseRepository<AssignmentsDTO>, DOBaseRepository<AssignmentsDTO>>();
            services.AddScoped<IDOBaseRepository<ProjectsDTO>, DOBaseRepository<ProjectsDTO>>();
            services.AddScoped<IDOBaseRepository<ReplyDTO>, DOBaseRepository<ReplyDTO>>();
            services.AddScoped<IDOBaseRepository<ContractorInfoDTO>, DOBaseRepository<ContractorInfoDTO>>();
            services.AddScoped<IDOBaseRepository<PlanRegisterDTO>, DOBaseRepository<PlanRegisterDTO>>();
            services.AddScoped<IDOBaseRepository<OperationProcessDTO>, DOBaseRepository<OperationProcessDTO>>();
            services.AddScoped<IDOBaseRepository<StepsProcessDTO>, DOBaseRepository<StepsProcessDTO>>();

            #region NGÂN SÁCH
            services.AddScoped<IDOBaseRepository<NS_CongViecDTO>, DOBaseRepository<NS_CongViecDTO>>();
            services.AddScoped<INS_CongViecRepository<NS_CongViec_CongViecDetailDTO>, NS_CongViecRepository<NS_CongViec_CongViecDetailDTO>>();

            services.AddScoped<IDOBaseRepository<NS_CongViecDetailDTO>, DOBaseRepository<NS_CongViecDetailDTO>>();
            services.AddScoped<INS_CongViecDetail_GoiThau_GiaiDoanRepository<NS_CongViecDetail_GoiThau_GiaiDoanDTO>, NS_CongViecDetail_GoiThau_GiaiDoanRepository<NS_CongViecDetail_GoiThau_GiaiDoanDTO>>();

            services.AddScoped<IDOBaseRepository<NS_GiaiDoanDTO>, DOBaseRepository<NS_GiaiDoanDTO>>();
            services.AddScoped<IDOBaseRepository<NS_GoiThauDTO>, DOBaseRepository<NS_GoiThauDTO>>();

            services.AddScoped<IDOBaseRepository<NS_HangMucDTO>, DOBaseRepository<NS_HangMucDTO>>();
            services.AddScoped<INS_HangMucRepository<NS_HangMuc_HangMucDetailDTO>, NS_HangMucRepository<NS_HangMuc_HangMucDetailDTO>>();

            services.AddScoped<IDOBaseRepository<NS_HangMucDetailDTO>, DOBaseRepository<NS_HangMucDetailDTO>>();
            services.AddScoped<IDOBaseRepository<NS_LoaiCongViecDTO>, DOBaseRepository<NS_LoaiCongViecDTO>>();
            services.AddScoped<IDOBaseRepository<NS_NhomChiPhiDTO>, DOBaseRepository<NS_NhomChiPhiDTO>>();

            services.AddScoped<IDOBaseRepository<NS_NhomCongViecDTO>, DOBaseRepository<NS_NhomCongViecDTO>>();
            services.AddScoped<INS_NhomCongViecRepository<NS_NhomCongViec_NhomCongViecDetailDTO>, NS_NhomCongViecRepository<NS_NhomCongViec_NhomCongViecDetailDTO>>();

            services.AddScoped<IDOBaseRepository<NS_NhomCongViecDetailDTO>, DOBaseRepository<NS_NhomCongViecDetailDTO>>();
            services.AddScoped<IDOBaseRepository<NS_ReasonDTO>, DOBaseRepository<NS_ReasonDTO>>();

            services.AddScoped<IDOBaseRepository<NS_PhatDTO>, DOBaseRepository<NS_PhatDTO>>();
            services.AddScoped<IDOBaseRepository<NS_Phat_NhomDTO>, DOBaseRepository<NS_Phat_NhomDTO>>();
            services.AddScoped<IDOBaseRepository<NS_Phat_TheoDoiDTO>, DOBaseRepository<NS_Phat_TheoDoiDTO>>();
            services.AddScoped<IDOBaseRepository<NS_KhauTruDTO>, DOBaseRepository<NS_KhauTruDTO>>();
            services.AddScoped<IDOBaseRepository<NS_KhauTru_TheoDoiDTO>, DOBaseRepository<NS_KhauTru_TheoDoiDTO>>();
            services.AddScoped<IDOBaseRepository<NS_TamUngDTO>, DOBaseRepository<NS_TamUngDTO>>();
            services.AddScoped<IDOBaseRepository<NS_TamUng_TheoDoiDTO>, DOBaseRepository<NS_TamUng_TheoDoiDTO>>();

            services.AddScoped<IDOBaseRepository<NS_NghiemThuDTO>, DOBaseRepository<NS_NghiemThuDTO>>(); 
            services.AddScoped<INS_NghiemThuRepository<NS_NghiemThuDetailDTO>, NS_NghiemThuRepository<NS_NghiemThuDetailDTO>>();

            services.AddScoped<IDOBaseRepository<NS_DuChiDTO>, DOBaseRepository<NS_DuChiDTO>>();
            services.AddScoped<IDOBaseRepository<NS_ThucChiDTO>, DOBaseRepository<NS_ThucChiDTO>>();
            #endregion

            services.AddScoped<IDOBaseRepository<RequestRegistDTO>, DOBaseRepository<RequestRegistDTO>>();
            services.AddScoped<IDOBaseRepository<ResponseRegistDTO>, DOBaseRepository<ResponseRegistDTO>>();
            services.AddScoped<IDOBaseRepository<ResponseRegistReplyDTO>, DOBaseRepository<ResponseRegistReplyDTO>>();
            services.AddScoped<IDOBaseRepository<WorkItemsDTO>, DOBaseRepository<WorkItemsDTO>>();
            services.AddScoped<IDOBaseRepository<DocumentReleasedDTO>, DOBaseRepository<DocumentReleasedDTO>>();
            services.AddScoped<IDOBaseRepository<DocumentReleasedAccountDTO>, DOBaseRepository<DocumentReleasedAccountDTO>>();
            services.AddScoped<IDOBaseRepository<DocumentReleasedLogDTO>, DOBaseRepository<DocumentReleasedLogDTO>>();
            services.AddScoped<IDOBaseRepository<AccountInfoDTO>, DOBaseRepository<AccountInfoDTO>>();
            services.AddScoped<IDOBaseRepository<PlanRegisterDTO>, DOBaseRepository<PlanRegisterDTO>>();

            services.AddScoped<IRequestRegistRepository<RequestRegistDTO>, RequestRegistRepository<RequestRegistDTO>>();
            services.AddScoped<IRequestRegistRepository<RequestRegistDetailDTO>, RequestRegistRepository<RequestRegistDetailDTO>>();
            services.AddScoped<IResponseRegistRepository<ResponseRegistDTO>, ResponseRegistRepository<ResponseRegistDTO>>();
            services.AddScoped<IFilesAttachmentRepository<FilesAttachmentDTO>, FilesAttachmentRepository<FilesAttachmentDTO>>();
            services.AddScoped<IPlanRegisterRepository<PlanRegisterDTO>, PlanRegisterRepository<PlanRegisterDTO>>();
            services.AddScoped<IDocumentReleasedRepository<DocumentReleasedDTO>, DocumentReleasedRepository<DocumentReleasedDTO>>();
            services.AddScoped<IDocumentReleasedLogRepository<DocumentReleasedLogDetailDTO>, DocumentReleasedLogRepository<DocumentReleasedLogDetailDTO>>();

            services.AddScoped<IDOBaseRepository<CustomCellContentDTO>, DOBaseRepository<CustomCellContentDTO>>();
            services.AddScoped<IDOBaseRepository<CustomColumDTO>, DOBaseRepository<CustomColumDTO>>();
            services.AddScoped<IDOBaseRepository<CustomFormBodyDTO>, DOBaseRepository<CustomFormBodyDTO>>();
            services.AddScoped<IDOBaseRepository<CustomFormContentDTO>, DOBaseRepository<CustomFormContentDTO>>();
            services.AddScoped<IDOBaseRepository<CustomFormDTO>, DOBaseRepository<CustomFormDTO>>();
            services.AddScoped<IDOBaseRepository<CustomFormAccountDTO>, DOBaseRepository<CustomFormAccountDTO>>();
            services.AddScoped<IDOBaseRepository<CustomTableDTO>, DOBaseRepository<CustomTableDTO>>();
            services.AddScoped<IDOBaseRepository<NotifyDTO>, DOBaseRepository<NotifyDTO>>();
            services.AddScoped<IDOBaseRepository<NotifyAccountDTO>, DOBaseRepository<NotifyAccountDTO>>();
            services.AddScoped<IDOBaseRepository<NotifyTemplateDTO>, DOBaseRepository<NotifyTemplateDTO>>();

            services.AddScoped<ICustomTableRepository<CustomTableDetailDTO>, CustomTableRepository<CustomTableDetailDTO>>();
            services.AddScoped<ICustomFormRepository<CustomFormDetailDTO>, CustomFormRepository<CustomFormDetailDTO>>();
            services.AddScoped<ICustomFormContentRepository<CustomFormContentDetailDTO>, CustomFormContentRepository<CustomFormContentDetailDTO>>();

            services.AddScoped<IDOBaseRepository<ConversationDTO>, DOBaseRepository<ConversationDTO>>();
            services.AddScoped<IDOBaseRepository<PlanAccountDTO>, DOBaseRepository<PlanAccountDTO>>();
            services.AddScoped<IDOBaseRepository<PlanJobDTO>, DOBaseRepository<PlanJobDTO>>();
            services.AddScoped<IDOBaseRepository<PlanMasterDTO>, DOBaseRepository<PlanMasterDTO>>();
            services.AddScoped<IDOBaseRepository<PlanProjectDTO>, DOBaseRepository<PlanProjectDTO>>();
            services.AddScoped<IDOBaseRepository<PlanReportDTO>, DOBaseRepository<PlanReportDTO>>();
            services.AddScoped<IDOBaseRepository<PlanScheduleDTO>, DOBaseRepository<PlanScheduleDTO>>();
            services.AddScoped<IPlanMasterRepository<PlanMasterAccountPermitDTO>, PlanMasterRepository<PlanMasterAccountPermitDTO>>();
            services.AddScoped<IPlanJobRepository<PlanJobAccountPermitDTO>, PlanJobRepository<PlanJobAccountPermitDTO>>();
            return services;
        }

        #endregion private functions
    }
}
