using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Services.Common.APIs.Cmd.EF.Extensions
{
    public static class SprocRepositoryExtensions
    {
        public static DbCommand LoadStoredProcedure(this DbContext context, string storedProcName)
        {
            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = storedProcName;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        public static DbCommand WithSqlParams(this DbCommand cmd, params (string, object)[] nameValues)
        {
            foreach (var pair in nameValues)
            {
                var param = cmd.CreateParameter();
                param.ParameterName = pair.Item1;
                param.Value = pair.Item2 ?? DBNull.Value; cmd.Parameters.Add(param);
            }
            return cmd;
        }
        public static IList<T> ExecuteStoredProcedure<T>(this DbCommand command) where T : class
        {
            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.MapToList<T>();
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
        public static async Task<IList<T>> ExecuteStoredProcedureAsync<T>(this DbCommand command) where T : class
        {
            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                    await command.Connection.OpenAsync();
                try
                {

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.MapToList<T>();
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
        public static async Task<List<DataTable>> ExecuteStoredProcedureAsync(this DbCommand command)
        {
            List<DataTable> dataTables = new List<DataTable>();
            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                    await command.Connection.OpenAsync();
                try
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataTables.Add(dataTable);
                        reader.NextResult();
                    }
                    return dataTables;
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
        public static async Task<DataTable> ExecuteStoredProcedureToTableAsync(this DbCommand command)
        {
            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                    await command.Connection.OpenAsync();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.MapToList();
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
        public static async Task<object> ExecuteScalarStoredProcedureAsync(this DbCommand command)
        {
            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                    await command.Connection.OpenAsync();
                try
                {
                    using (var reader = command.ExecuteScalarAsync())
                    {
                        return await reader;
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
        public static async Task ExecuteNonQueryStoredProcedureAsync(this DbCommand command)
        {
            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                    await command.Connection.OpenAsync();
                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
        private static IList<T> MapToList<T>(this DbDataReader dr)
        {
            var objList = new List<T>();
            var props = typeof(T).GetRuntimeProperties();
            var colMapping = dr.GetColumnSchema()
                        .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                        .ToDictionary(key => key.ColumnName.ToLower());
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        var val = dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                        prop.SetValue(obj, val == DBNull.Value ? null : val);
                    }
                    objList.Add(obj);
                }
            }
            return objList;
        }
        private static DataTable MapToList(this DbDataReader dr)
        {
            DataTable objTable = new DataTable();
            //var props = typeof(T).GetRuntimeProperties();
            var colMapping = dr.GetColumnSchema()
                            .ToDictionary(key => key.ColumnName.ToLower());
            foreach (var col in colMapping)
            {
                objTable.Columns.Add(col.Key);
                objTable.Columns[col.Key].DataType = col.Value.DataType;
            }
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataRow row = objTable.NewRow();
                    foreach (DataColumn colName in objTable.Columns)
                    {
                        row[colName.ColumnName] = (dr.GetValue(colName.ColumnName));
                    }
                    objTable.Rows.Add(row);
                }
            }
            return objTable;
        }
        private static DataTable MapToTable(this DbDataReader dr)
        {
            DataTable objTable = new DataTable();
            objTable.Load(dr);
            return objTable;
        }
    }
}
