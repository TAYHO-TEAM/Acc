using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.DTOs;
using Services.Common.APIs.Cmd.EF;
using System.Reflection;

namespace ProjectManager.CMD.Infrastructure
{
    public class ProjectManagerBaseContext : DbContext
    {
        public ProjectManagerBaseContext(DbContextOptions<ProjectManagerBaseContext> options) : base(options)
        {
        }
        public DbSet<Domain.DTOs.AccountInfo> AccountInfo { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<ContractorInfo> ContractorInfo { get; set; }
        public DbSet<DocumentReleased> DocumentReleased { get; set; }
        public DbSet<DocumentReleasedAccount> DocumentReleasedAccount { get; set; }
        public DbSet<DocumentReleasedLog> DocumentReleasedLog { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<FilesAttachment> FilesAttachment { get; set; }
        public DbSet<Functions> Functions { get; set; }
        public DbSet<GroupAccount> GroupAccount { get; set; }
        public DbSet<GroupActionPermistion> GroupActionPermistion { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupStages> GroupStages { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<GroupFunctionPermistion> GroupFunctionPermistion { get; set; }
        public DbSet<GroupStepProcessPermistion> GroupStepProcessPermistion { get; set; }
        public DbSet<GroupAction> GroupAction { get; set; }

        #region Ngân sách
        public DbSet<NS_CongViec> NS_CongViec { get; set; }
        public DbSet<NS_CongViecDetail> NS_CongViecDetail { get; set; }
        public DbSet<NS_GiaiDoan> NS_GiaiDoan { get; set; }
        public DbSet<NS_GoiThau> NS_GoiThau { get; set; }
        public DbSet<NS_HangMuc> NS_HangMuc { get; set; }
        public DbSet<NS_HangMucDetail> NS_HangMucDetail { get; set; }
        public DbSet<NS_KhauTru> NS_KhauTru { get; set; }
        public DbSet<NS_KhauTru_TheoDoi> NS_KhauTru_TheoDoi { get; set; }
        public DbSet<NS_LoaiCongViec> NS_LoaiCongViec { get; set; }
        public DbSet<NS_NhomChiPhi> NS_NhomChiPhi { get; set; }
        public DbSet<NS_NhomCongViec> NS_NhomCongViec { get; set; }
        public DbSet<NS_NhomCongViecDetail> NS_NhomCongViecDetail { get; set; }
        public DbSet<NS_Phat> NS_Phat { get; set; }
        public DbSet<NS_Phat_Nhom> NS_Phat_Nhom { get; set; }
        public DbSet<NS_Phat_TheoDoi> NS_Phat_TheoDoi { get; set; }
        public DbSet<NS_Reason> NS_Reason { get; set; }
        public DbSet<NS_TamUng> NS_TamUng { get; set; }
        public DbSet<NS_TamUng_TheoDoi> NS_TamUng_TheoDoi { get; set; }
        public DbSet<NS_DuChi> NS_DuChi { get; set; }
        public DbSet<NS_ThucChi> NS_ThucChi { get; set; }
        #endregion
        public DbSet<OperationProcess> OperationProcess { get; set; }
        public DbSet<PlanRegister> PlanRegister { get; set; }
        public DbSet<ProblemCategory> ProblemCategory { get; set; }
        public DbSet<Reply> Reply { get; set; }
        public DbSet<RequestDetail> RequestDetail { get; set; }
        public DbSet<RequestRegist> RequestRegist { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<ResponseRegist> ResponseRegist { get; set; }
        public DbSet<ResponseRegistReply> ResponseRegistReply { get; set; }
        public DbSet<Stages> Stages { get; set; }
        public DbSet<StepsProcess> StepsProcess { get; set; }
        public DbSet<CustomCellContent> CustomCellContent { get; set; }
        public DbSet<CustomColum> CustomColum { get; set; }
        public DbSet<CustomForm> CustomForm { get; set; }
        public DbSet<CustomFormBody> CustomFormBody { get; set; }
        public DbSet<CustomFormContent> CustomFormContent { get; set; }
        public DbSet<CustomTable> CustomTable { get; set; }
        public DbSet<PlanAccount> PlanAccount { get; set; }
        public DbSet<PlanJob> PlanJob { get; set; }
        public DbSet<PlanMaster> PlanMaster { get; set; }
        public DbSet<PlanProject> PlanProject { get; set; }
        public DbSet<PlanReport> PlanReport { get; set; }
        public DbSet<PlanSchedule> PlanSchedule { get; set; }
        public DbSet<CustomFormAccount> CustomFormAccount { get; set; }
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<Notify> Notify { get; set; }
        public DbSet<NotifyAccount> NotifyAccount { get; set; }
        public DbSet<NotifyTemplate> NotifyTemplate { get; set; }
        public DbSet<TemplateMail> TemplateMail { get; set; }
        public DbSet<NotifyConfig> NotifyConfig { get; set; }
        public DbSet<NotifyConfigLog> NotifyConfigLog { get; set; }
        public DbSet<SysAutoSendMail> SysAutoSendMail { get; set; }
        public DbSet<SysJob> SysJob { get; set; }
        public DbSet<SysJobParameter> SysJobParameter { get; set; }
        public DbSet<SysJobTable> SysJobTable { get; set; }
        public DbSet<SysMailAccount> SysMailAccount { get; set; }
        public DbSet<SysJobColum> SysJobColum { get; set; }

        #region Bilder View Table
        public DbSet<DocumentReleasedLogDetail> DocumentReleasedLogDetail { get; set; }
        public DbSet<NotifyAccountDetail> NotifyAccountDetail { get; set; }
        public DbSet<PlanJobAccount> PlanJobAccount { get; set; }
        public DbSet<PlanMasterAccount> PlanMasterAccount { get; set; }


        #endregion Bilder View Table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<NS_GiaiDoan>();
        }
    }
}
