using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;

namespace Services.Common.DevExpress
{
    public class DevexpressHelper
    {
        public DevRequestLoadOptionsViewModel devRequestLoadOptionsViewModel { get; set; }
        public DevexpressHelper()
        {
            devRequestLoadOptionsViewModel = new DevRequestLoadOptionsViewModel();
        }
    }
    public class DevRequestViewModel //: DataSourceLoadOptions
    {
        public string nameEF { get; set; }

        public DevRequestLoadOptionsViewModel devRequestLoadOptionsViewModel { get; set; }
        public DevRequestViewModel()
        {
            devRequestLoadOptionsViewModel = new DevRequestLoadOptionsViewModel();
        }
    }
    public class DataSourceLoadOptionsHelper : DataSourceLoadOptionsBase
    {
    }
    public class DevRequestLoadOptionsViewModel : DataSourceLoadOptionsBase
    {
        public string searchOperation { get; set; }
        public string searchValue { get; set; }
        public List<string> searchExpr { get; set; } = new List<string>();

    }
    //DataSourceLoadOptionsBase
    //"sort": [
    //  {
    //                    "selector": "string",
    //    "desc": true
    //  }
    //], ----------------------
    public class sort
    {
        public string selector { get; set; }
        public bool desc { get; set; }
    }

    //"group": [
    //  {
    //                    "groupInterval": "string",
    //    "isExpanded": true,
    //    "selector": "string",
    //    "desc": true
    //  }
    //],
    public class group
    {
        public string groupInterval { get; set; }
        public bool isExpanded { get; set; }
        public string selector { get; set; }
        public bool desc { get; set; }
    }
    //"totalSummary": [
    //  {
    //                    "selector": "string",
    //    "summaryType": "string"
    //  }
    //],
    public class totalSummary
    {
        public string selector { get; set; }
        public string summaryType { get; set; }
    }
    //"groupSummary": [
    //  {
    //                    "selector": "string",
    //    "summaryType": "string"
    //  }
    //],
    public class groupSummary
    {
        public string selector { get; set; }
        public string summaryType { get; set; }
    }
    public class DataLoadOptions
    {
        public bool? requireTotalCount { get; set; }
        public bool? requireGroupCount { get; set; }
        public int? skip { get; set; }
        public int? take { get; set; }
        public List<sort> sort { get; set; }
        public List<group> group { get; set; }
        public List<object> filter { get; set; }
        public List<totalSummary> totalSummary { get; set; }
        public List<string> select { get; set; }
        public List<string> preSelect { get; set; }
        public bool? remoteSelect { get; set; }
        public bool? remoteGrouping { get; set; }
        public bool? expandLinqSumType { get; set; }
        public List<string> primaryKey { get; set; }
        public string defaultSort { get; set; }
        public bool? stringToLower { get; set; }
        public bool? paginateViaPrimaryKey { get; set; }
        public bool? sortByPrimaryKey { get; set; }
        public bool? allowAsyncOverSync { get; set; }

        public DataLoadOptions()
        {
            sort = new List<sort>();
            group = new List<group>();
            filter = new List<object>();
            totalSummary = new List<totalSummary>();
            select = new List<string>();
            preSelect = new List<string>();
            primaryKey = new List<string>();
        }
    }
    public class DataLoadOptionsHelper
    {
        public static bool? StringToLowerDefault { get; set; }
        public bool? PaginateViaPrimaryKey { get; set; }
        public bool? StringToLower { get; set; }
        public string DefaultSort { get; set; }
        public string PrimaryKey { get; set; }
        public bool? ExpandLinqSumType { get; set; }
        public bool? RemoteGrouping { get; set; }
        public bool? RemoteSelect { get; set; }
        public string PreSelect { get; set; }
        public string Select { get; set; }
        public string GroupSummary { get; set; }
        public string TotalSummary { get; set; }
        public string Filter { get; set; }
        public string Group { get; set; }
        public string Sort { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSummaryQuery { get; set; }
        public bool? IsCountQuery { get; set; }
        public bool? RequireGroupCount { get; set; }
        public bool? RequireTotalCount { get; set; }
        public bool? SortByPrimaryKey { get; set; }
        public bool? AllowAsyncOverSync { get; set; }
    }


    //    {
    //            "dataSourceLoadOptions": {
    //                "requireTotalCount": true, ---
    //"requireGroupCount": true, ---
    //"isCountQuery": true,
    //"skip": 0,
    //"take": 0,
    //"filter": [
    //  { }
    //],
    //"select": [
    //  "string"
    //              ],
    //"preSelect": [
    //  "string"
    //              ],
    //"remoteSelect": true,
    //"remoteGrouping": true,
    //"expandLinqSumType": true,
    //"primaryKey": [
    //  "string"
    //              ],
    //"defaultSort": "string",
    //"stringToLower": true,--------
    //"paginateViaPrimaryKey": true,
    //"sortByPrimaryKey": true,
    //"allowAsyncOverSync": true
    //            }
    //        }
    public static class DevexpressHelperFunction
    {
        public static IList ConvertFilter(IList filter)
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
        public static IList ConvertFilter(string filter)
        {

            if (!string.IsNullOrEmpty(filter))
            {
                var _filter = JsonConvert.DeserializeObject<IList>(filter.ToString());
                IList newList = new List<object>();
                foreach (var item in _filter)
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
            else
            {
                return null;
            }
        }
        public static IList ConvertSearch(string searchOperation, string searchValue, List<string> searchExpr)
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
                    if (i < searchExpr.Count)
                    {
                        newList.Add("or");
                    }
                    i++;
                }
            }
            return newList;
        }
        public static DataSourceLoadOptionsBase ConvertFromDataLoadOptionsHelper(DataLoadOptionsHelper dataLoadOptionsHelper)
        {
            DataSourceLoadOptionsBase dataSourceLoadOptionsBase = new DataSourceLoadOptionsBase();
            //var temp = JsonConvert.SerializeObject(dataLoadOptionsHelper);
            //JsonConvert.PopulateObject(temp, dataSourceLoadOptionsBase);
            dataSourceLoadOptionsBase.RequireTotalCount = dataLoadOptionsHelper.RequireTotalCount.HasValue ? (bool)dataLoadOptionsHelper.RequireTotalCount : false;
            dataSourceLoadOptionsBase.RequireGroupCount = dataLoadOptionsHelper.RequireGroupCount.HasValue ? (bool)dataLoadOptionsHelper.RequireGroupCount : false;
            dataSourceLoadOptionsBase.AllowAsyncOverSync = dataLoadOptionsHelper.AllowAsyncOverSync.HasValue ? (bool)dataLoadOptionsHelper.AllowAsyncOverSync : false;
            dataSourceLoadOptionsBase.SortByPrimaryKey = dataLoadOptionsHelper.SortByPrimaryKey.HasValue ? (bool)dataLoadOptionsHelper.SortByPrimaryKey : false;
            dataSourceLoadOptionsBase.IsCountQuery = dataLoadOptionsHelper.IsCountQuery.HasValue ? (bool)dataLoadOptionsHelper.IsCountQuery : false;
            dataSourceLoadOptionsBase.IsSummaryQuery = dataLoadOptionsHelper.IsSummaryQuery.HasValue ? (bool)dataLoadOptionsHelper.IsSummaryQuery : false;
            dataSourceLoadOptionsBase.RemoteSelect = dataLoadOptionsHelper.RemoteSelect.HasValue ? (bool)dataLoadOptionsHelper.RemoteSelect : false;
            dataSourceLoadOptionsBase.RemoteGrouping = dataLoadOptionsHelper.RemoteGrouping.HasValue ? (bool)dataLoadOptionsHelper.RemoteGrouping : false;
            dataSourceLoadOptionsBase.ExpandLinqSumType = dataLoadOptionsHelper.ExpandLinqSumType.HasValue ? (bool)dataLoadOptionsHelper.ExpandLinqSumType : false;
            dataSourceLoadOptionsBase.StringToLower = dataLoadOptionsHelper.StringToLower.HasValue ? (bool)dataLoadOptionsHelper.StringToLower : false;
            dataSourceLoadOptionsBase.PaginateViaPrimaryKey = dataLoadOptionsHelper.PaginateViaPrimaryKey.HasValue ? (bool)dataLoadOptionsHelper.PaginateViaPrimaryKey : false;
            //dataSourceLoadOptionsBase.StringToLowerDefault = dataLoadOptionsHelper.StringToLowerDefault.HasValue ? (bool)dataLoadOptionsHelper.StringToLowerDefault : false;
            dataSourceLoadOptionsBase.DefaultSort = dataLoadOptionsHelper.DefaultSort;
            dataSourceLoadOptionsBase.PrimaryKey = JsonConvert.DeserializeObject<string[]>(string.IsNullOrEmpty(dataLoadOptionsHelper.PrimaryKey) ? "" : dataLoadOptionsHelper.PrimaryKey);
            dataSourceLoadOptionsBase.PreSelect = string.IsNullOrEmpty(dataLoadOptionsHelper.PreSelect) ? null : JsonConvert.DeserializeObject<string[]>(dataLoadOptionsHelper.PreSelect);
            dataSourceLoadOptionsBase.Select = dataLoadOptionsHelper.Select == null ? null : JsonConvert.DeserializeObject<string[]>(dataLoadOptionsHelper.Select);
            dataSourceLoadOptionsBase.GroupSummary = dataLoadOptionsHelper.GroupSummary == null ? null : JsonConvert.DeserializeObject<SummaryInfo[]>(dataLoadOptionsHelper.GroupSummary);
            dataSourceLoadOptionsBase.TotalSummary = dataLoadOptionsHelper.TotalSummary == null ? null : JsonConvert.DeserializeObject<SummaryInfo[]>(dataLoadOptionsHelper.TotalSummary);
            dataSourceLoadOptionsBase.Group = dataLoadOptionsHelper.Group == null ? null : JsonConvert.DeserializeObject<GroupingInfo[]>(dataLoadOptionsHelper.Group);
            dataSourceLoadOptionsBase.Sort = dataLoadOptionsHelper.Sort == null ? null : JsonConvert.DeserializeObject<SortingInfo[]>(dataLoadOptionsHelper.Sort);
            //dataSourceLoadOptionsBase.TotalSummary = JsonConvert.DeserializeObject<SummaryInfo[]>(dataLoadOptionsHelper.GroupSummary);
            //JsonConvert.PopulateObject(dataLoadOptionsHelper.PrimaryKey, dataSourceLoadOptionsBase.PrimaryKey);
            //JsonConvert.PopulateObject(dataLoadOptionsHelper.PreSelect, dataSourceLoadOptionsBase.PreSelect);
            //JsonConvert.PopulateObject(dataLoadOptionsHelper.Select, dataSourceLoadOptionsBase.Select);
            //JsonConvert.PopulateObject(dataLoadOptionsHelper.GroupSummary, dataSourceLoadOptionsBase.GroupSummary);
            //JsonConvert.PopulateObject(dataLoadOptionsHelper.TotalSummary, dataSourceLoadOptionsBase.TotalSummary);
            //JsonConvert.PopulateObject(dataLoadOptionsHelper.Group, dataSourceLoadOptionsBase.Group);
            //JsonConvert.PopulateObject(dataLoadOptionsHelper.Sort, dataSourceLoadOptionsBase.Sort);
            dataSourceLoadOptionsBase.Filter = ConvertFilter(dataLoadOptionsHelper.Filter);
            dataSourceLoadOptionsBase.Take = dataLoadOptionsHelper.Take;
            dataSourceLoadOptionsBase.Skip = dataLoadOptionsHelper.Skip;
            return dataSourceLoadOptionsBase;
        }
        public static void mappingDataSourceLoading(DataLoadOptionsHelper dataSourceLoadOptionsBase)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataSourceLoadOptions, DataSourceLoadOptionsHelper>();
            });
            configuration.AssertConfigurationIsValid();
            var mapper = configuration.CreateMapper();
            var loadOptions = mapper.Map<DataSourceLoadOptions>(dataSourceLoadOptionsBase);
        }
    }

}
