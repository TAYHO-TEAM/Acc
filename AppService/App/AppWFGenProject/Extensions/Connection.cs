using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AppWFGenProject.Extensions
{
    public class Connection
    {
        public bool ConnectTest(string server, string user, string pass, string db)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = server;
                builder.UserID = user;
                builder.Password = pass;
                builder.InitialCatalog = db;

                // Connect to SQL
                //Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    connection.Close();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                return false;

            }
        }
        public SqlConnectionStringBuilder Connect(string server, string user, string pass, string db)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.UserID = user;
            builder.Password = pass;
            builder.InitialCatalog = db;
            return builder;
        }
        public SqlConnectionStringBuilder Connect()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ConfigurationSettings.AppSettings["DataSource"].ToString();
            builder.UserID = ConfigurationSettings.AppSettings["UserID"].ToString();
            builder.Password = ConfigurationSettings.AppSettings["Password"].ToString();
            builder.InitialCatalog = ConfigurationSettings.AppSettings["InitialCatalog"].ToString();
            return builder;
        }
        public List<string> GetAllTable(string server, string user, string pass, string db)
        {
            DataTable dt = new DataTable();
            List<string> listTable = new List<string>();
            string queryString = @"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME NOT LIKE 'sysdiagrams'  AND TABLE_CATALOG = '" + db + "' ORDER BY TABLE_NAME ASC";
            using (SqlConnection cnn = new SqlConnection(Connect(server, user, pass, db).ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd = new SqlCommand(queryString, cnn);
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            listTable.Add(reader["TABLE_NAME"].ToString());
                            //Console.WriteLine(String.Format("{0}, {1}", reader["tPatCulIntPatIDPk"], reader["tPatSFirstname"]));// etc
                        }
                    }
                    finally
                    {
                        reader.Close();
                        cmd.Dispose();
                        cnn.Close();
                    }
                    cnn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
            return listTable;
        }
        public IConfiguration _configuration;
        public DataTable GetAllEntry(string db, string selectkey, string colname)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnn = new SqlConnection(Connect().ConnectionString))
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    
                    string _storeproce = ConfigurationSettings.AppSettings["SPGetALLEntry"].ToString();
                    try
                    {
                        cmd = new SqlCommand(_storeproce, cnn);
                        cmd.Parameters.Add(new SqlParameter("@DBlink", db));
                        cmd.Parameters.Add(new SqlParameter("@SearchKey", selectkey));
                        cmd.Parameters.Add(new SqlParameter("@ColName", "[" + colname + "]"));
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        cmd.Dispose();
                        cnn.Close();
                    }
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
            return dt;
        }
        public DataSet GetAllCode(string server, string user, string pass, string db, string TableName, string BackList = "Id,IsDelete,IsActive,IsVisible,IsModify,CreateBy,CreateDateUTC,CreateDate,ModifyBy,UpdateDateUTC,UpdateDate,Status")
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(Connect(server, user, pass, db).ConnectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    string _storeproce = "sp_GenEntity_DO";// ConfigurationSettings.AppSettings["SPGetALLEntry"].ToString();

                    using (SqlCommand cmd = new SqlCommand(_storeproce, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Tables", TableName));
                        cmd.Parameters.Add(new SqlParameter("@BackList", BackList));
                        cmd.CommandType = CommandType.StoredProcedure;
                        cnn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds);
                        cnn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
            return ds;
        }
        public HashSet<string> ConvertDTRowsToList(DataTable dt, string colname)
        {
            HashSet<string> _newList = new HashSet<string>();
            foreach (DataRow row in dt.Rows)
            {
                _newList.Add(row[colname].ToString());
            }
            return _newList;
        }
        public HashSet<string> getListEntry(string db, string selectkey, string colname)
        {
            DataTable dt = GetAllEntry(db, selectkey, colname);
            return ConvertDTRowsToList(dt, colname);
        }
    }
}
