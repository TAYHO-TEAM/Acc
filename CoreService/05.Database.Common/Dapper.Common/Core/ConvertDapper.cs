using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapper.Common.Core
{
    public static class ConvertDapper
    {
        public static DataTable ConvetTableDpperGrid(SqlMapper.GridReader  gridReader)
        {
            DataTable convertedTable = new DataTable();
            var rows = gridReader.Read<dynamic>().ToList();
            convertedTable = ToDataTable(rows);
            return convertedTable;
        }
        public static DataTable ToDataTable(IEnumerable<dynamic> items)
        {
            if (items == null) return null;
            var data = items.ToArray();
            if (data.Length == 0) return null;

            var dt = new DataTable();
            foreach (var pair in ((IDictionary<string, object>)data[0]))
            {
                dt.Columns.Add(pair.Key, (pair.Value ?? string.Empty).GetType());
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }
    }
}
