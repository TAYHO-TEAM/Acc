using Dapper;
using Dapper.Common;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Infrastructure;
using ProjectManager.Read.Sql.DTOs.BaseClasses;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProjectManager.Read.Sql.Repositories
{
    public class ProjectManagerRepository : IProjectManagerRepository
    {
        protected readonly ProjectManagerBaseContext _dbContext;
        //protected readonly ISqlConnectionFactory _connectionFactory;
        public ProjectManagerRepository(ProjectManagerBaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
            //_connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        public async Task<LoadResult> GetAll(int user, string nameEF, DevLoadOptionsBase dataSourceLoadOptionsBase, string searchOperation, string searchValue, List<string> searchExpr)
        {
            List<int?> getActionId = _dbContext.Functions
                                                .Where(c => c.TableName == nameEF
                                                        && c.ActionId != null 
                                                        && (c.IsDelete == false || !c.IsDelete.HasValue))
                                                .Select(x => x.ActionId).ToList();

            bool checkPermit = _dbContext.GroupAccount
                                        .Join(_dbContext.GroupActionPermistion, x => x.GroupId, y => y.GroupId, (y, x) => new { y, x })
                                        .Any(c => c.y.AccountId == user
                                            && c.x.PermistionId == 6
                                            && getActionId.Contains(c.x.ActionId)
                                            && (c.x.IsDelete == false || !c.x.IsDelete.HasValue)
                                            && (c.y.IsDelete == false || !c.y.IsDelete.HasValue));

            dynamic objEF = ConvertEF(nameEF);
            if (objEF != null)
            {
                if (dataSourceLoadOptionsBase.Filter.Count > 1)
                {
                    dataSourceLoadOptionsBase.Filter = ConvertFilter(dataSourceLoadOptionsBase.Filter);
                }
                //else
                //{
                //    dataSourceLoadOptionsBase.Filter = JsonConvert.DeserializeObject<IList>(dataSourceLoadOptionsBase.Filter[0].ToString());
                //}
                if (!checkPermit && getActionId.Count > 0)
                {
                    IList filterOwnerBy = ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""createBy"",""=""," + user.ToString() + @"]"));
                    IList filterDeleteNull = ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""isDelete"",""IS NULL""]"));
                    IList filterDeleteFalse = ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""isDelete"",""=""," + 0 + @"]"));
                    IList filterIsDelete = new List<object>();
                    filterIsDelete.Add(filterDeleteNull);
                    filterIsDelete.Add("or");
                    filterIsDelete.Add(filterDeleteFalse);
                    IList filter = new List<object>();
                    filter.Add(filterOwnerBy);
                    filter.Add("and");
                    filter.Add(filterDeleteFalse);
                    if (dataSourceLoadOptionsBase.Filter.Count > 0)
                    {
                        filter.Add("and");
                        filter.Add(dataSourceLoadOptionsBase.Filter);
                    }
                    //if (dataSourceLoadOptionsBase.Filter.Count > 0)
                    //{
                    //    dataSourceLoadOptionsBase.Filter.Add("and");
                    //}
                    //dataSourceLoadOptionsBase.Filter.Add(filterOwnerBy);
                    //if (dataSourceLoadOptionsBase.Filter.Count > 0)
                    //{
                    //    dataSourceLoadOptionsBase.Filter.Add("and");
                    //}
                    dataSourceLoadOptionsBase.Filter = filter;
                }
                if(searchExpr.Count> 0 && searchExpr != null && !string.IsNullOrEmpty(searchValue))
                {
                    if (dataSourceLoadOptionsBase.Filter.Count > 0)
                    {
                        IList newList = new List<object>();
                        newList.Add(dataSourceLoadOptionsBase.Filter);
                        newList.Add("and");
                        dataSourceLoadOptionsBase.Filter = newList;
                    }
                    dataSourceLoadOptionsBase.Filter.Add(ConvertSearch(searchOperation, searchValue,searchExpr)) ;
                }    
                return DataSourceLoader.Load(objEF, dataSourceLoadOptionsBase);
            }
            else
            {
                return new LoadResult();
            }

        }
        public async Task<string> GetAccount2(DevLoadOptionsBase dataSourceLoadOptionsBase)
        {
            var objEF = _dbContext.NS_GiaiDoan;
            if (dataSourceLoadOptionsBase.Filter.Count > 1)
            {
                dataSourceLoadOptionsBase.Filter = ConvertFilter(dataSourceLoadOptionsBase.Filter);
            }
            return JsonConvert.SerializeObject(DataSourceLoader.Load(objEF, dataSourceLoadOptionsBase));
        }
        private dynamic ConvertEF(string nameEntity)
        {
            dynamic orders = null;
            switch (nameEntity)
            {
                case nameof(_dbContext.AccountInfo):
                    orders = _dbContext.AccountInfo;
                    break;
                //case nameof(_dbContext.Accounts):
                //    orders = _dbContext.Accounts;
                //    break;
                //case nameof(_dbContext.Actions):
                //    orders = _dbContext.Actions;
                //    break;
                //case nameof(_dbContext.Assignments):
                //    orders = _dbContext.Assignments;
                //    break;
                //case nameof(_dbContext.Categorys):
                //    orders = _dbContext.Categorys;
                //    break;
                case nameof(_dbContext.ContractorInfo):
                    orders = _dbContext.ContractorInfo;
                    break;
                case nameof(_dbContext.Conversation):
                    orders = _dbContext.Conversation;
                    break;
                case nameof(_dbContext.CustomCellContent):
                    orders = _dbContext.CustomCellContent;
                    break;
                case nameof(_dbContext.CustomColum):
                    orders = _dbContext.CustomColum;
                    break;
                case nameof(_dbContext.CustomForm):
                    orders = _dbContext.CustomForm;
                    break;
                case nameof(_dbContext.CustomFormAccount):
                    orders = _dbContext.CustomFormAccount;
                    break;
                case nameof(_dbContext.CustomFormBody):
                    orders = _dbContext.CustomFormBody;
                    break;
                case nameof(_dbContext.CustomFormContent):
                    orders = _dbContext.CustomFormContent;
                    break;
                //case nameof(_dbContext.CustomFormContentApprove):
                //    orders = _dbContext.CustomFormContentApprove;
                //    break;
                case nameof(_dbContext.CustomTable):
                    orders = _dbContext.CustomTable;
                    break;
                //case nameof(_dbContext.DeviceAccount):
                //    orders = _dbContext.DeviceAccount;
                //    break;
                case nameof(_dbContext.DocumentReleased):
                    orders = _dbContext.DocumentReleased;
                    break;
                case nameof(_dbContext.DocumentReleasedAccount):
                    orders = _dbContext.DocumentReleasedAccount;
                    break;
                case nameof(_dbContext.DocumentReleasedLog):
                    orders = _dbContext.DocumentReleasedLog;
                    break;
                case nameof(_dbContext.DocumentType):
                    orders = _dbContext.DocumentType;
                    break;
                case nameof(_dbContext.FilesAttachment):
                    orders = _dbContext.FilesAttachment;
                    break;
                case nameof(_dbContext.Functions):
                    orders = _dbContext.Functions;
                    break;
                case nameof(_dbContext.GroupAccount):
                    orders = _dbContext.GroupAccount;
                    break;
                //case nameof(_dbContext.GroupAction):
                //    orders = _dbContext.GroupAction;
                //    break;
                case nameof(_dbContext.GroupActionPermistion):
                    orders = _dbContext.GroupActionPermistion;
                    break;
                //case nameof(_dbContext.GroupFunctionPermistion):
                //    orders = _dbContext.GroupFunctionPermistion;
                //    break;
                //case nameof(_dbContext.GroupPermistion):
                //    orders = _dbContext.GroupPermistion;
                //    break;
                case nameof(_dbContext.Groups):
                    orders = _dbContext.Groups;
                    break;
                case nameof(_dbContext.GroupStages):
                    orders = _dbContext.GroupStages;
                    break;
                //case nameof(_dbContext.GroupStepProcessPermistion):
                //    orders = _dbContext.GroupStepProcessPermistion;
                //    break;
                //case nameof(_dbContext.LogEvent):
                //    orders = _dbContext.LogEvent;
                //    break;
                case nameof(_dbContext.Notify):
                    orders = _dbContext.Notify;
                    break;
                case nameof(_dbContext.NotifyAccount):
                    orders = _dbContext.NotifyAccount;
                    break;
                case nameof(_dbContext.NotifyTemplate):
                    orders = _dbContext.NotifyTemplate;
                    break;
                case nameof(_dbContext.NS_CongViec):
                    orders = _dbContext.NS_CongViec;
                    break;
                case nameof(_dbContext.NS_CongViecDetail):
                    orders = _dbContext.NS_CongViecDetail;
                    break;
                //case nameof(_dbContext.NS_CongViecDetail_GoiThau):
                //    orders = _dbContext.NS_CongViecDetail_GoiThau;
                //    break;
                case nameof(_dbContext.NS_DuChi):
                    orders = _dbContext.NS_DuChi;
                    break;
                case nameof(_dbContext.NS_GiaiDoan):
                    orders = _dbContext.NS_GiaiDoan;
                    break;
                case nameof(_dbContext.NS_GoiThau):
                    orders = _dbContext.NS_GoiThau;
                    break;
                case nameof(_dbContext.NS_HangMuc):
                    orders = _dbContext.NS_HangMuc;
                    break;
                case nameof(_dbContext.NS_HangMucDetail):
                    orders = _dbContext.NS_HangMucDetail;
                    break;
                case nameof(_dbContext.NS_KhauTru):
                    orders = _dbContext.NS_KhauTru;
                    break;
                case nameof(_dbContext.NS_KhauTru_TheoDoi):
                    orders = _dbContext.NS_KhauTru_TheoDoi;
                    break;
                case nameof(_dbContext.NS_LoaiCongViec):
                    orders = _dbContext.NS_LoaiCongViec;
                    break;
                //case nameof(_dbContext.NS_NghiemThu):
                //    orders = _dbContext.NS_NghiemThu;
                //    break;
                case nameof(_dbContext.NS_NhomChiPhi):
                    orders = _dbContext.NS_NhomChiPhi;
                    break;
                case nameof(_dbContext.NS_NhomCongViec):
                    orders = _dbContext.NS_NhomCongViec;
                    break;
                case nameof(_dbContext.NS_NhomCongViecDetail):
                    orders = _dbContext.NS_NhomCongViecDetail;
                    break;
                case nameof(_dbContext.NS_Phat):
                    orders = _dbContext.NS_Phat;
                    break;
                case nameof(_dbContext.NS_Phat_Nhom):
                    orders = _dbContext.NS_Phat_Nhom;
                    break;
                case nameof(_dbContext.NS_Phat_TheoDoi):
                    orders = _dbContext.NS_Phat_TheoDoi;
                    break;
                case nameof(_dbContext.NS_Reason):
                    orders = _dbContext.NS_Reason;
                    break;
                case nameof(_dbContext.NS_TamUng):
                    orders = _dbContext.NS_TamUng;
                    break;
                case nameof(_dbContext.NS_TamUng_TheoDoi):
                    orders = _dbContext.NS_TamUng_TheoDoi;
                    break;
                case nameof(_dbContext.NS_ThucChi):
                    orders = _dbContext.NS_ThucChi;
                    break;
                case nameof(_dbContext.OperationProcess):
                    orders = _dbContext.OperationProcess;
                    break;
                //case nameof(_dbContext.Permistions):
                //    orders = _dbContext.Permistions;
                //    break;
                case nameof(_dbContext.PlanAccount):
                    orders = _dbContext.PlanAccount;
                    break;
                case nameof(_dbContext.PlanJob):
                    orders = _dbContext.PlanJob;
                    break;
                case nameof(_dbContext.PlanMaster):
                    orders = _dbContext.PlanMaster;
                    break;
                case nameof(_dbContext.PlanProject):
                    orders = _dbContext.PlanProject;
                    break;
                case nameof(_dbContext.PlanRegister):
                    orders = _dbContext.PlanRegister;
                    break;
                case nameof(_dbContext.PlanReport):
                    orders = _dbContext.PlanReport;
                    break;
                case nameof(_dbContext.PlanSchedule):
                    orders = _dbContext.PlanSchedule;
                    break;
                case nameof(_dbContext.ProblemCategory):
                    orders = _dbContext.ProblemCategory;
                    break;
                case nameof(_dbContext.Projects):
                    orders = _dbContext.Projects;
                    break;
                //case nameof(_dbContext.RelationTable):
                //    orders = _dbContext.RelationTable;
                //    break;
                case nameof(_dbContext.Reply):
                    orders = _dbContext.Reply;
                    break;
                case nameof(_dbContext.RequestDetail):
                    orders = _dbContext.RequestDetail;
                    break;
                case nameof(_dbContext.RequestRegist):
                    orders = _dbContext.RequestRegist;
                    break;
                case nameof(_dbContext.Requests):
                    orders = _dbContext.Requests;
                    break;
                case nameof(_dbContext.ResponseRegist):
                    orders = _dbContext.ResponseRegist;
                    break;
                case nameof(_dbContext.ResponseRegistReply):
                    orders = _dbContext.ResponseRegistReply;
                    break;
                //case nameof(_dbContext.StaffTayHo):
                //    orders = _dbContext.StaffTayHo;
                //    break;
                case nameof(_dbContext.Stages):
                    orders = _dbContext.Stages;
                    break;
                case nameof(_dbContext.StepsProcess):
                    orders = _dbContext.StepsProcess;
                    break;
                case nameof(_dbContext.DocumentReleasedLogDetail):
                    orders = _dbContext.DocumentReleasedLogDetail;
                    break;
                case nameof(_dbContext.NotifyAccountDetail):
                    orders = _dbContext.NotifyAccountDetail;
                    break;
                case nameof(_dbContext.PlanJobAccount):
                    orders = _dbContext.PlanJobAccount;
                    break;
                case nameof(_dbContext.PlanMasterAccount):
                    orders = _dbContext.PlanMasterAccount;
                    break;
                default:
                    orders = null;
                    break;
            }
            return orders;
        }
        private IList ConvertSearch(string searchOperation, string searchValue, List<string> searchExpr)
        {
            IList newList = new List<object>();
            if (searchExpr.Count > 0 && !string.IsNullOrEmpty(searchValue))
            {
                int i = 1;
                foreach (var searchItem in searchExpr)
                {
                   
                    IList item = new List<string>();
                    item.Add(searchItem);
                    item.Add(searchOperation);
                    item.Add(searchValue);
                    newList.Add(item);
                    if(i< searchExpr.Count)
                    {
                        newList.Add("or");
                    }    
                    i++;
                }    
            }
            return newList;
        }
        private IList ConvertFilter(IList filter)
        {
            IList newList = new List<object>();
            foreach (var item in filter)
            {
                if (item != null)
                {
                    if (item.ToString().Length > 0)
                    {

                        if (item.ToString().Substring(0, 1) == "[")
                        {
                            IList lString = ConvertFilter(JsonConvert.DeserializeObject<IList>(item.ToString()));
                            newList.Add(lString);
                        }
                        else
                        {
                            //newList.Add(JsonConvert.DeserializeObject < ((JsonElement)item).ValueKind > (item.ToString()))

                            //newList.Add(((JsonElement)item));///JsonConvert.DeserializeObject<IList>(item.ToString()));
                            string valueKid = "";
                            try
                            {
                                valueKid = ((JsonElement)item).ValueKind.ToString();
                            }
                            catch
                            {

                            }
                            if (valueKid == "String")
                            {
                                newList.Add(item.ToString());
                            }
                            else if (valueKid == "Number")
                            {

                                newList.Add(Convert.ToInt32(item.ToString()));
                            }
                            else
                            {
                                newList.Add(item);
                            }

                        }
                    }
                    else
                    {
                        newList.Add(item);
                    }
                }
                else
                {
                    newList.Add(item);
                }
                //newList.Add(item);
            }
            return newList;
        }
    }
}
