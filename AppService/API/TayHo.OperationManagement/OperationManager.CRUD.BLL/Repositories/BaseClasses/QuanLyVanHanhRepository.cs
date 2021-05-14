using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OperationManager.CRUD.BLL.Extensions;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;
using OperationManager.CRUD.DAL.DBContext;
using OperationManager.CRUD.DAL.DTO;
using OperationManager.CRUD.DAL.DTO.BaseClasses;
using Services.Common.DevExpress;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OperationManager.CRUD.BLL.Repositories.BaseClasses
{
    public class QuanLyVanHanhRepository<T> : IQuanLyVanHanhRepository<T> where T : DOBase
    {
        protected readonly QuanLyVanHanhContext _dbContext;
        public QuanLyVanHanhRepository(QuanLyVanHanhContext dbContext)
        {
            _dbContext = dbContext;
            //_dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public async Task<LoadResult> GetAll(int user, string nameEF, DataSourceLoadOptions dataSourceLoadOptionsBase)
        {
            int actionType = 1; //// 1 : Read 
            //var abc = _dbContext.Database.ExecuteSqlCommand("CreateStudents @p0, @p1", parameters: new[] { "Bill", "Gates" });
            List<int?> getActionId = new List<int?>();
            getActionId.Add(1);
            //List<int?> getActionId = _dbContext.Functions
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

            dynamic objEF = ConvertEF(nameEF);
            if (objEF != null)
            {
                if (dataSourceLoadOptionsBase.Filter != null)
                {
                    if (dataSourceLoadOptionsBase.Filter.Count > 1)
                    {
                        dataSourceLoadOptionsBase.Filter = DevexpressHelperFunction.ConvertFilter(dataSourceLoadOptionsBase.Filter);
                    }
                    //else
                    //{
                    //    dataSourceLoadOptionsBase.Filter = JsonConvert.DeserializeObject<IList>(dataSourceLoadOptionsBase.Filter[0].ToString());
                    //}
                }


                if (!checkPermit && getActionId.Count > 0)
                {
                    IList filterOwnerBy = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""createBy"",""=""," + user.ToString() + @"]"));
                    IList filterDeleteNull = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""isDelete"",""IS NULL""]"));
                    IList filterDeleteFalse = DevexpressHelperFunction.ConvertFilter(JsonConvert.DeserializeObject<IList>(@"[""isDelete"",""=""," + 0 + @"]"));
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
                    dataSourceLoadOptionsBase.Filter = filter;
                }
                return DataSourceLoader.Load(objEF, dataSourceLoadOptionsBase);
            }
            else
            {
                return new LoadResult();
            }

        }
        public async Task<LoadResult> GetAll(int user, string nameEF, DataSourceLoadOptions dataSourceLoadOptionsBase, string searchOperation, string searchValue, List<string> searchExpr)
        {
            //var abc = _dbContext.Database.ExecuteSqlCommand("CreateStudents @p0, @p1", parameters: new[] { "Bill", "Gates" });
            List<int?> getActionId = new List<int?>();

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

            dynamic objEF = ConvertEF(nameEF);
            if (objEF != null)
            {
                if (dataSourceLoadOptionsBase.Filter.Count > 1)
                {
                    dataSourceLoadOptionsBase.Filter = DevexpressHelperFunction.ConvertFilter(dataSourceLoadOptionsBase.Filter);
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
                    dataSourceLoadOptionsBase.Filter = filter;
                }
                if (searchExpr.Count > 0 && searchExpr != null && !string.IsNullOrEmpty(searchValue))
                {
                    if (dataSourceLoadOptionsBase.Filter.Count > 0)
                    {
                        IList newList = new List<object>();
                        newList.Add(dataSourceLoadOptionsBase.Filter);
                        newList.Add("and");
                        dataSourceLoadOptionsBase.Filter = newList;
                    }
                    dataSourceLoadOptionsBase.Filter.Add(DevexpressHelperFunction.ConvertSearch(searchOperation, searchValue, searchExpr));
                }
                return DataSourceLoader.Load(objEF, dataSourceLoadOptionsBase);
            }
            else
            {
                return new LoadResult();
            }

        }
        public async Task<MethodResult<T>> Insert(int user, string nameEF, T Model)
        {
            int _function = 2;
            //if ((await _ContractorInfoRepository.BaseCheckPermistion(0, _user, _actionId, _tableName, _function)) < 1)
            //{
            //    methodResult.AddAPIErrorMessage(nameof(ErrorCodeInsert.IErrN101), new[]
            //   {
            //        ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
            //    });
            //}
            var methodResult = new MethodResult<T>();
            try
            {
                DbSet<T> objEF = ConvertEF(nameEF);
                Model.CreateBy = user;        
                objEF.Add(Model);
                //var a =_dbContext.Add(Model).Entity;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                methodResult.AddErrorMessage("Lỗi xứ lý");
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            methodResult.Result = Model;
            return methodResult;
        }
        public async Task<MethodResult<T>> Update(int user, string nameEF, T model)
        {

            var methodResult = new MethodResult<T>();
            DbSet<T> objEF = ConvertEF(nameEF);
            if (await objEF.AnyAsync(x => x.Id == model.Id && model.IsDelete != true).ConfigureAwait(false))
            {
                model.IsModify = true;
                model.ModifyBy = user;
                model.UpdateDate = DateTime.Now;
                model.UpdateDateUTC = DateTime.UtcNow;
                objEF.Update(model);
                await _dbContext.SaveChangesAsync();
                methodResult.Result = model;
            }
            else
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(model.Id),model.Id)
                });
            }

            return methodResult;
        }
        public async Task<MethodResult<T>> Delete(int user, string nameEF, int key)
        {

            var methodResult = new MethodResult<T>();
            DbSet<T> objEF = ConvertEF(nameEF);
            var model = await objEF.SingleOrDefaultAsync(x => x.Id == key ).ConfigureAwait(false);
            if (model != null && model.IsDelete != true)
            {

                model.IsModify = true;
                model.ModifyBy = user;
                model.UpdateDate = DateTime.Now;
                model.UpdateDateUTC = DateTime.UtcNow;
                model.IsDelete = true;
                objEF.Update(model);
                await _dbContext.SaveChangesAsync();
                methodResult.Result = model;
            }
            else
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
              {
                    ErrorHelpers.GenerateErrorResult(nameof(model.Id),model.Id)
                });
            }
            return methodResult;
        }

        private dynamic ConvertEF(string nameEntity)
        {
            dynamic orders = null;
            switch (nameEntity)
            {

                case nameof(_dbContext.TestApi):
                    orders = _dbContext.TestApi;
                    break;
                default:
                    orders = null;
                    break;
            }
            return orders;
        }
    }
}
