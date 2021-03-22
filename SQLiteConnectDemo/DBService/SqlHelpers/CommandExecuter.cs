using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SQLiteConnectDemo.DBService.SqlHelpers
{
    public class CommandExecuter
    {
        public static SqliteCommand QueryCommand(string Query, SqliteConnection conn, SqliteParameter[] parameters, int cmdTimeout)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Query;
            cmd.CommandTimeout = cmdTimeout;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            return cmd;
        }
        public static SqliteCommand SPCommand(string ProcName, SqliteConnection conn, SqliteParameter[] parameters,int cmdTimeout)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcName;
            cmd.CommandTimeout = cmdTimeout;
            if(parameters!=null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            return cmd;
        }

        public static SqliteCommand SPCommandWithOutput(string ProcName, SqliteConnection conn, SqliteParameter[] parameters, int cmdTimeout,String OutParam)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcName;
            cmd.CommandTimeout = cmdTimeout;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            cmd.Parameters[OutParam].Direction = System.Data.ParameterDirection.Output;
            return cmd;
        }
    }
}