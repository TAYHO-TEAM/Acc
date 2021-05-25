using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OperationManager.CRUD.BLL.Extensions;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;
using OperationManager.CRUD.DAL.DBContext;
using OperationManager.CRUD.DAL.DTO;
using OperationManager.CRUD.DAL.DTO.BaseClasses;
using Services.Common.APIs.Cmd.EF;
using Services.Common.APIs.Cmd.EF.Extensions;
using Services.Common.DevExpress;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Media;
using Services.Common.Options;
using Services.Common.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace OperationManager.CRUD.BLL.Repositories.BaseClasses
{
    public class QuanLyVanHanhRepository<T> : IQuanLyVanHanhRepository<T> where T : DOBase
    {
        protected readonly QuanLyVanHanhContext _dbContext;
        protected readonly MediaOptions _mediaOptions;
        private CancellationToken _cancellationToken = default;
        public QuanLyVanHanhRepository(QuanLyVanHanhContext dbContext, IOptionsSnapshot<MediaOptions> snapshotOptionsAccessor)
        {
            _dbContext = dbContext;
            _mediaOptions = snapshotOptionsAccessor.Value;
            //_cancellationToken = cancellationToken;
            //_dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
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
                if (loadOptions.Filter != null)
                {
                    if (loadOptions.Filter.Count > 0)
                    {
                        var _filter = DevexpressHelperFunction.ConvertFilter(loadOptions.Filter);
                        loadOptions.Filter.Clear();
                        loadOptions.Filter = _filter;
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
                    if (loadOptions.Filter.Count > 0)
                    {
                        filter.Add("and");
                        filter.Add(loadOptions.Filter);
                    }
                    loadOptions.Filter.Clear();
                    loadOptions.Filter = filter;
                }
                return await DataSourceLoader.LoadAsync(objEF, loadOptions);
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

            dynamic objEF = ConvertEF(nameEF);
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
                    IList filterIsDelete = new List<object>();
                    filterIsDelete.Add(filterDeleteNull);
                    filterIsDelete.Add("or");
                    filterIsDelete.Add(filterDeleteFalse);
                    IList filter = new List<object>();
                    filter.Add(filterOwnerBy);
                    filter.Add("and");
                    filter.Add(filterDeleteFalse);
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
                return DataSourceLoader.Load(objEF, loadOptions);
            }
            else
            {
                return new LoadResult();
            }

        }
        public async Task<MethodResult<T>> Insert(int user, string nameEF, T Model, IFormFileCollection formFiles = null)
        {
        
            int _function = 2;
            var methodResult = new MethodResult<T>();
            if (!await CheckPermission(user, _function))
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodePermission.PErr101), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(Model.Id),Model.Id)
                });
            }
            try
            {
                DbSet<T> objEF = ConvertEF(nameEF);
                Model.CreateBy = user;
                objEF.Add(Model);
                //var a =_dbContext.Add(Model).Entity;
                await _dbContext.SaveChangesAndDispatchEventsAsync(_cancellationToken).ConfigureAwait(false);
                if (formFiles != null)
                {
                    if (formFiles.Count > 0)
                    {
                       await UploadFile(formFiles, Model.Id, nameEF, "", user );
                    }
                }
              

            }
            catch (Exception ex)
            {
                methodResult.AddErrorMessage("Lỗi xứ lý");
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            methodResult.Result = Model;
            return methodResult;
        }
        public async Task<MethodResult<T>> Update(int user, string nameEF, T model, IFormFileCollection formFiles = null)
        {
            int _function = 3;
            var methodResult = new MethodResult<T>();
            DbSet<T> objEF = ConvertEF(nameEF);
            dynamic existsModel = await objEF.FirstOrDefaultAsync(x => x.Id == model.Id && model.IsDelete != true).ConfigureAwait(false);
            if (!await CheckPermission(user, _function))
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodePermission.PErr101), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(model.Id),model.Id)
                });
            }
            else if (existsModel != null)
            {
                ConvertHelper.CopyNonNullProperties(model, existsModel);
                existsModel.IsModify = true;
                existsModel.ModifyBy = user;
                existsModel.UpdateDate = DateTime.Now;
                existsModel.UpdateDateUTC = DateTime.UtcNow;
                objEF.Update(existsModel);
                await _dbContext.SaveChangesAndDispatchEventsAsync(_cancellationToken).ConfigureAwait(false);
                if (formFiles != null)
                {
                    if (formFiles.Count > 0)
                    {
                        await UploadFile(formFiles, existsModel.Id, nameEF, "", user);
                    }
                }
                methodResult.Result = existsModel;
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
            int _function = 4;
            var methodResult = new MethodResult<T>();
            DbSet<T> objEF = ConvertEF(nameEF);
            var model = await objEF.SingleOrDefaultAsync(x => x.Id == key).ConfigureAwait(false);
            if (!await CheckPermission(user, _function))
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodePermission.PErr101), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(model.Id),model.Id)
                });
            }
            else if (model != null && model.IsDelete != true)
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
        private async Task<bool> CheckPermission(int user, int action)
        {
            return true;
        }
        public async Task LogEventSQL(int AccountId = 0, string Action = "", string Event = "", string Infomation = "")
        {
            try
            {
                (string, object)[] parameter = new (string, object)[] { ("@AccountId", AccountId), ("@Action", Action), ("@Event", Event), ("@Infomation", Infomation) };
                SprocRepository _sprocRepository = new SprocRepository(_dbContext);
                IList<ResultCheck> result = await _sprocRepository.GetStoredProcedure("sp_DataBase_Log_CMD")
                            .WithSqlParams(parameter)
                            .ExecuteStoredProcedureAsync<ResultCheck>();
            }
            catch
            {

            }
        }
        private dynamic ConvertEF(string nameEntity)
        {
            dynamic orders = null;
            switch (nameEntity)
            {
                case nameof(_dbContext.ConstructionCategory):
                    orders = _dbContext.ConstructionCategory;
                    break;
                case nameof(_dbContext.Conversation):
                    orders = _dbContext.Conversation;
                    break;
                case nameof(_dbContext.CustomerInfo):
                    orders = _dbContext.CustomerInfo;
                    break;
                case nameof(_dbContext.CustomerRealEstate):
                    orders = _dbContext.CustomerRealEstate;
                    break;
                case nameof(_dbContext.DefectAcceptance):
                    orders = _dbContext.DefectAcceptance;
                    break;
                case nameof(_dbContext.DefectFeedback):
                    orders = _dbContext.DefectFeedback;
                    break;
                case nameof(_dbContext.DefectFix):
                    orders = _dbContext.DefectFix;
                    break;
                case nameof(_dbContext.Defective):
                    orders = _dbContext.Defective;
                    break;
                case nameof(_dbContext.ConstructionItems):
                    orders = _dbContext.ConstructionItems;
                    break;
                case nameof(_dbContext.LogEvent):
                    orders = _dbContext.LogEvent;
                    break;
                case nameof(_dbContext.Project):
                    orders = _dbContext.Project;
                    break;
                case nameof(_dbContext.RealEstate):
                    orders = _dbContext.RealEstate;
                    break;
                case nameof(_dbContext.FilesAttachment):
                    orders = _dbContext.FilesAttachment;
                    break;
                case nameof(_dbContext.TestApi):
                    orders = _dbContext.TestApi;
                    break;
                default:
                    orders = null;
                    break;
            }
            return orders;
        }
        public async Task UploadFile(IFormFileCollection request, int ownerById = 0, string tableName = "", string code = "", int userid = 0)
        {
            var methodResult = new MethodResult<FilesAttachment>();
            List<FilesAttachment> filesAttachments = new List<FilesAttachment>();
            // ghi file vào server và lưu log file dữ liệu List<FilesAttachment>
            if (request != null && request.Count > 0)
            {
                foreach (var i in request)
                {
                    var result = await FileHelpers.SaveFile(i, tableName, code, _mediaOptions);
                    if(result!= null)
                    {
                        FilesAttachment filesAttachment = new FilesAttachment();
                        filesAttachment.OwnerById = ownerById;
                        filesAttachment.OwnerByTable = tableName;
                        filesAttachment.Code = code;
                        filesAttachment.FileName = result.Item1;
                        filesAttachment.Host = result.Item2;
                        filesAttachment.Url = result.Item3;
                        filesAttachment.Direct = result.Item4;
                        filesAttachment.Tail = result.Item5;
                        filesAttachment.DisplayName = result.Item6;
                        filesAttachment.SetCreate(userid);
                        filesAttachment.Status = 0;
                        filesAttachment.IsActive = true;
                        filesAttachment.IsVisible = true;
                        filesAttachment.IsDelete = false;
                        filesAttachments.Add(filesAttachment);
                    }    
                    //_dbContext.FilesAttachment.Add(filesAttachment);
                    //await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                }
                if(filesAttachments.Count>0)
                {
                    //await Insert(userid, "FilesAttachment", filesAttachments).ConfigureAwait(false);
                    await _dbContext.FilesAttachment.AddRangeAsync(filesAttachments);
                    await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                    //await _dbContext.SaveChangesAndDispatchEventsAsync(_cancellationToken);
                }

            }
            else
            {
                methodResult.AddErrorMessage("Lỗi xứ lý");
            }
        }
        
    }

}
