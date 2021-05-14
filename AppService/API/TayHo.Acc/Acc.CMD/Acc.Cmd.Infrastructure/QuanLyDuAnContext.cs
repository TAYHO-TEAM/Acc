using Acc.Cmd.Domain.DomainObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Common.APIs.Cmd.EF;
using System;
using System.Reflection;

namespace Acc.Cmd.Infrastructure
{
    public class QuanLyDuAnContext : BaseDbContext
    {
        public QuanLyDuAnContext(DbContextOptions<QuanLyDuAnContext> options, IMediator mediator) : base(options, mediator)
        {
        }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Actions> Actions { get; set; }
        public DbSet<Categorys> Categorys { get; set; }
        public DbSet<ContractorInfo> ContractorInfo { get; set; }
        public DbSet<DeviceAccount> DeviceAccount { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Functions> Functions { get; set; }
        public DbSet<GroupAccount> GroupAccount { get; set; }
        public DbSet<GroupAction> GroupAction { get; set; }
        public DbSet<GroupFunctionPermistion> GroupFunctionPermistion { get; set; }
        public DbSet<GroupPermistion> GroupPermistion { get; set; }
        public DbSet<GroupActionPermistion> GroupActionPermistion { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupStages> GroupStages { get; set; }
        public DbSet<Permistions> Permistions { get; set; }
        public DbSet<ProblemCategory> ProblemCategory { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<RelationTable> RelationTable { get; set; }
        public DbSet<StaffTayHo> StaffTayHo { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<OperationProcess> OperationProcess { get; set; }
        public DbSet<StepsProcess> StepsProcess { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
