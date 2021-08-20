using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OperationManager.CRUD.BLL.IRepositories;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;
using OperationManager.CRUD.DAL.DBContext;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;
using Services.Common.DevExpress;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.CRUD.BLL.Repositories
{
    public class SysJobWithAccountRepository : ISysJobWithAccountRepository
    {
        protected readonly QuanLyVanHanhContext _dbContext;
        public SysJobWithAccountRepository(QuanLyVanHanhContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoadResult> GetAll(int user, string nameEF, DataLoadOptionsHelper dataSourceLoadOptionsBase)
        {
            int actionType = 1; //// 1 : Read 
            List<int?> getActionId = new List<int?>();
            getActionId.Add(1);
            //List<int?> getActionId = _dbContext.Functions
            //.Where(c => c.TableName == nameEF
            //        && c.Type == 1
            //        && c.ActionId != null
            //        && (c.IsDelete == false || !c.IsDelete.HasValue))
            //.Select(x => x.ActionId).ToList();
            //ConvertHelper.CopyNonNullProperties(loadOptions, dataSourceLoadOptionsBase);

            var loadOptions = DevexpressHelperFunction.ConvertFromDataLoadOptionsHelper(dataSourceLoadOptionsBase);

            bool checkPermit = true;/// CheckPermission(0,user,1, nameEF,1);//_dbContext.GroupAccount
            //.Join(_dbContext.GroupActionPermistion, x => x.GroupId, y => y.GroupId, (y, x) => new { y, x })
            //.Any(c => c.y.AccountId == user
            //    && c.x.PermistionId == 6
            //    && getActionId.Contains(c.x.ActionId)
            //    && (c.x.IsDelete == false || !c.x.IsDelete.HasValue)
            //    && (c.y.IsDelete == false || !c.y.IsDelete.HasValue));
            dynamic objEF = _dbContext.SysJobWithAccount;
            if (objEF != null)
            {
                if (loadOptions.Filter != null)
                {
                    if (loadOptions.Filter.Count > 0)
                    {
                        IList _filter = DevexpressHelperFunction.ConvertFilter(loadOptions.Filter);
                        loadOptions.Filter.Clear();
                        loadOptions.Filter = _filter;
                    }
                    //else
                    //{
                    //    dataSourceLoadOptionsBase.Filter = JsonConvert.DeserializeObject<IList>(dataSourceLoadOptionsBase.Filter[0].ToString());
                    //}
                }
                if (checkPermit && getActionId.Count > 0) //!checkPermit &&
                {
                    //IList filterOwnerBy = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""createBy"",""=""," + user.ToString() + @"]"));
                    IList filterDeleteNull = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""isDelete"",""IS NULL""]"));
                    IList filterDeleteFalse = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""isDelete"",""=""," + 0 + @"]"));
                    IList filterAccount = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""accountId"",""=""," + user.ToString() + @"]"));
                    IList filterIsDelete = new List<object>();
                    filterIsDelete.Add(filterDeleteNull);
                    filterIsDelete.Add("or");
                    filterIsDelete.Add(filterDeleteFalse);
                    IList filter = new List<object>();
                    filter.Add(filterIsDelete);
                    filter.Add("and");
                    filter.Add(filterAccount);
                    if (loadOptions.Filter != null)
                    {
                        IList _filter = DevexpressHelperFunction.ConvertFilter(loadOptions.Filter);
                        filter.Add("and");
                        filter.Add(_filter);
                        loadOptions.Filter.Clear();
                    }

                    loadOptions.Filter = filter;
                }
                else if (!checkPermit && getActionId.Count > 0)
                {
                    IList filterOwnerBy = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""createBy"",""=""," + (string.IsNullOrEmpty(user.ToString()) ? "0" : user.ToString()) + @"]"));
                    IList filterDeleteNull = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""isDelete"",""IS NULL""]"));
                    IList filterDeleteFalse = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""isDelete"",""=""," + 0 + @"]"));
                    IList filterAccount = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""accountId"",""=""," + user.ToString() + @"]"));
                    IList filterIsDelete = new List<object>();
                    filterIsDelete.Add(filterDeleteNull);
                    filterIsDelete.Add("or");
                    filterIsDelete.Add(filterDeleteFalse);
                    IList filter = new List<object>();
                    filter.Add(filterOwnerBy);
                    filter.Add("and");
                    filter.Add(filterIsDelete);
                    if (loadOptions.Filter != null)
                    {
                        IList _filter = DevexpressHelperFunction.ConvertFilter(loadOptions.Filter);
                        filter.Add("and");
                        filter.Add(_filter);
                        loadOptions.Filter.Clear();
                    }
                    loadOptions.Filter = filter;
                }
                return  DataSourceLoader.Load(objEF, loadOptions);
            }
            else
            {
                return new LoadResult();
            }
        }
        public async Task<LoadResult> GetAll(int user, string nameEF, DataSourceLoadOptionsHelper dataSourceLoadOptionsBase, string searchOperation, string searchValue, List<string> searchExpr)
        {
            //var abc = _dbContext.Database.ExecuteSqlCommand("CreateStudents @p0, @p1", parameters: new[] { "Bill", "Gates" });
            List<int?> getActionId = new List<int?>();
            DataSourceLoadOptionsBase loadOptions = new DataSourceLoadOptionsBase();
            getActionId.Add(1);
            /// _dbContext.Functions
            //.Where(c => c.TableName == nameEF
            //        && c.Type == 1
            //        && c.ActionId != null
            //        && (c.IsDelete == false || !c.IsDelete.HasValue))
            //.Select(x => x.ActionId).ToList();

            bool checkPermit = true;// _dbContext.GroupAccount
                                    //.Join(_dbContext.GroupActionPermistion, x => x.GroupId, y => y.GroupId, (y, x) => new { y, x })
                                    //.Any(c => c.y.AccountId == user
                                    //    && c.x.PermistionId == 6
                                    //    && getActionId.Contains(c.x.ActionId)
                                    //    && (c.x.IsDelete == false || !c.x.IsDelete.HasValue)
                                    //    && (c.y.IsDelete == false || !c.y.IsDelete.HasValue));

            dynamic objEF = _dbContext.SysJobWithAccount;
            if (objEF != null)
            {
                if (loadOptions.Filter.Count > 1)
                {
                    loadOptions.Filter = DevexpressHelperFunction.ConvertFilter(loadOptions.Filter);
                }
                //else
                //{
                //    dataSourceLoadOptionsBase.Filter = JsonConvert.DeserializeObject<IList>(dataSourceLoadOptionsBase.Filter[0].ToString());
                //}
                if (!checkPermit && getActionId.Count > 0)
                {
                    IList filterOwnerBy = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""createBy"",""=""," + user.ToString() + @"]"));
                    IList filterDeleteNull = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""isDelete"",""IS NULL""]"));
                    IList filterDeleteFalse = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""isDelete"",""=""," + 0 + @"]"));
                    IList filterAccount = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""accountId"",""=""," + user.ToString() + @"]"));
                    IList filterIsDelete = new List<object>();
                    filterIsDelete.Add(filterDeleteNull);
                    filterIsDelete.Add("or");
                    filterIsDelete.Add(filterDeleteFalse);
                    IList filter = new List<object>();
                    filter.Add(filterOwnerBy);
                    filter.Add("and");
                    filter.Add(filterDeleteFalse);
                    filter.Add("and");
                    filter.Add(filterAccount);
                    if (loadOptions.Filter.Count > 0)
                    {
                        filter.Add("and");
                        filter.Add(loadOptions.Filter);
                       
                    }
                    loadOptions.Filter = filter;
                }
                if (searchExpr.Count > 0 && searchExpr != null && !string.IsNullOrEmpty(searchValue))
                {
                    if (loadOptions.Filter.Count > 0)
                    {
                        IList newList = new List<object>();
                        newList.Add(loadOptions.Filter);
                        newList.Add("and");
                        loadOptions.Filter = newList;
                    }
                    loadOptions.Filter.Add(DevexpressHelperFunction.ConvertSearch(searchOperation, searchValue, searchExpr));
                }
                return await DataSourceLoader.LoadAsync(objEF, loadOptions);
            }
            else
            {
                return new LoadResult();
            }

        }
    }
}
