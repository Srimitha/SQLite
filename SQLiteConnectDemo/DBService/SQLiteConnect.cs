using Microsoft.Data.Sqlite;
using SQLiteConnectDemo.DBService.SqlHelpers;
using SQLiteConnectDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
//using SqlitenetWrapper;
namespace SQLiteConnectDemo.DBService
{
    public class SQLiteConnect:IDisposable
    {
        //SqliteConnection conn = new SqliteConnection("data source=chinook.db");

        //conn
        //SqliteCommand cmd =conn;
        //string query = "select * from albums";
        SqliteConnection connection = null;
        SqliteCommand cmd = null;
        
        public SQLiteConnect()
        {
            connection = new SqliteConnection("data source=chinook.db");
            cmd = new SqliteCommand();
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
        
        public List<Customers> GetCustomerByID(Int32 CustomerID)
        {
            List<Customers> customers = null;
            try
            {
                customers = new List<Customers>();
                SqliteParameter[] parameters = new SqliteParameter[]
                {
                    new SqliteParameter("",SqliteType.Integer){ Value=CustomerID}
                };
                //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_whatever());
                connection.Open();
                cmd = CommandExecuter.QueryCommand(SQLQuery.GetCustomerByID, connection, parameters, 60);
                SqliteDataReader reader=  cmd.ExecuteReader();
                while(reader.Read())
                {
                    Customers cust = new Customers();
                    cust.FirstName = (reader["FirstName"]!=DBNull.Value)?reader.GetString(reader.GetOrdinal("FirstName")):null;
                }
                return customers;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        ~SQLiteConnect()
        {
            if(cmd!=null)
            {
                cmd.Dispose();
            }
            if(connection!=null)
            {
                if(connection.State==ConnectionState.Open)
                {
                    connection.Close();
                    
                }
                connection.Dispose();
            }
        }
    }
}