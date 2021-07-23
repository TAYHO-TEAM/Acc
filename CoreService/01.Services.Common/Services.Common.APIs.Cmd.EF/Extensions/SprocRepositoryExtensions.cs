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
                    DataTable dataTable = new DataTable();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                        reader.NextResult();
                    }
                    dataTables.Add(dataTable);
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
        //public static async Task<List<IEnumerable>> ExecuteStoredProcedureAsync(this DbContext context, DbCommand command) 
        //{
        //    List<Func<IObjectContextAdapter, DbDataReader, IEnumerable>> _resultSets = new List<Func<IObjectContextAdapter, DbDataReader, IEnumerable>>();
        //    var results = new List<IEnumerable>();
        //    using (command)
        //    {
        //        if (command.Connection.State == ConnectionState.Closed)
        //            await command.Connection.OpenAsync();
        //        try
        //        {

        //            using (var reader = command.ExecuteReader())
        //            {
        //                var adapter = ((IObjectContextAdapter)context);
        //                foreach (var resultSet in _resultSets)
        //                {
        //                    results.Add(resultSet(adapter, reader));
        //                    reader.NextResult();
        //                }
        //            }
        //            return results;
        //        }
        //        finally
        //        {
        //            command.Connection.Close();
        //        }
        //    }
        //}
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
            foreach(var col in colMapping)
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
                        row[colName.ColumnName] =(dr.GetValue(colName.ColumnName));
                    }
                    objTable.Rows.Add(row);
                }
            }
            return objTable;
        }
    }
}
