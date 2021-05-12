using DevExtreme.AspNet.Data;
using System;
using System.Collections.Generic;
using System.Text;

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
    public class DataSourceLoadOptions : DataSourceLoadOptionsBase
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

}
