using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;

namespace SmartDeviceProject1
{
    public static class SqlCeLib
    {
        private static SqlCeConnection m_sqlCeConn;

        private static SqlCeTransaction m_sqlCeTrans;

        public static string ConnectionString
        {
            get
            {
                return SqlCeLib.m_sqlCeConn.ConnectionString;
            }
            set
            {
                SqlCeLib.m_sqlCeConn.ConnectionString = value;
            }
        }

        public static SqlCeConnection sqlCeConn
        {
            get
            {
                return SqlCeLib.m_sqlCeConn;
            }
        }

        public static SqlCeTransaction sqlCeTrans
        {
            get
            {
                return SqlCeLib.m_sqlCeTrans;
            }
            set
            {
                SqlCeLib.m_sqlCeTrans = value;
            }
        }

        static SqlCeLib()
        {
            SqlCeLib.m_sqlCeConn = new SqlCeConnection();
        }

        public static void BulkInsert(string TableName, DataTable datatable, bool DeleteBeforeInsert)
        {
            try
            {
                try
                {
                    SqlCeLib.Connection(SqlCeLib.ConnStatus.Open);
                    SqlCeCommand sqlCeCommand = SqlCeLib.sqlCeConn.CreateCommand();
                    try
                    {
                        sqlCeCommand.Connection = SqlCeLib.sqlCeConn;
                        sqlCeCommand.Transaction=SqlCeLib.sqlCeTrans;
                        sqlCeCommand.CommandType = CommandType.Text;
                        if (DeleteBeforeInsert)
                        {
                            sqlCeCommand.CommandText = string.Format("Delete From {0}", TableName);
                            sqlCeCommand.ExecuteNonQuery();
                        }
                        sqlCeCommand.CommandText = string.Format("Select * From {0}", TableName);
                        SqlCeResultSet sqlCeResultSet = sqlCeCommand.ExecuteResultSet(ResultSetOptions.Sensitive);
                        try
                        {
                            SqlCeUpdatableRecord sqlCeUpdatableRecord = sqlCeResultSet.CreateRecord();
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                for (int j = 0; j < datatable.Columns.Count; j++)
                                {
                                    sqlCeUpdatableRecord.SetValue(j, datatable.Rows[i][j]);
                                }
                                sqlCeResultSet.Insert(sqlCeUpdatableRecord);
                            }
                        }
                        finally
                        {
                            if (sqlCeResultSet != null)
                            {
                                sqlCeResultSet.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (sqlCeCommand != null)
                        {
                            sqlCeCommand.Dispose();
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
                SqlCeLib.Connection(SqlCeLib.ConnStatus.Close);
            }
        }

        public static void Connection(SqlCeLib.ConnStatus Status)
        {
            try
            {
                switch (Status)
                {
                    case SqlCeLib.ConnStatus.Open:
                        {
                            if (SqlCeLib.sqlCeConn.State == ConnectionState.Closed)
                            {
                                SqlCeLib.sqlCeConn.Open();
                            }
                            break;
                        }
                    case SqlCeLib.ConnStatus.Close:
                        {
                            if ((SqlCeLib.sqlCeConn.State != ConnectionState.Open ? false : SqlCeLib.sqlCeTrans == null))
                            {
                                SqlCeLib.sqlCeConn.Close();
                            }
                            break;
                        }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void CreateDatabase()
        {
            try
            {
                SqlCeEngine sqlCeEngine = new SqlCeEngine();
                try
                {
                    sqlCeEngine.LocalConnectionString=SqlCeLib.ConnectionString;
                    sqlCeEngine.CreateDatabase();
                }
                finally
                {
                    if (sqlCeEngine != null)
                    {
                        sqlCeEngine.Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static object Execute(string CommandText, SqlCeLib.ExecMode Mode, params SqlCeParameter[] CommandParameter)
        {
            object obj;
            try
            {
                try
                {
                    SqlCeLib.Connection(SqlCeLib.ConnStatus.Open);
                    SqlCeCommand commandText = SqlCeLib.sqlCeConn.CreateCommand();
                    try
                    {
                        commandText.Connection=SqlCeLib.sqlCeConn;
                        commandText.Transaction=SqlCeLib.sqlCeTrans;
                        commandText.CommandType = CommandType.Text;
                        commandText.CommandText = CommandText;
                        commandText.CommandTimeout = 0;
                        commandText.Parameters.Clear();
                        if ((int)CommandParameter.Length > 0)
                        {
                            commandText.Parameters.AddRange(CommandParameter);
                        }
                        switch (Mode)
                        {
                            case SqlCeLib.ExecMode.Scalar:
                                {
                                    obj = commandText.ExecuteScalar();
                                    return obj;
                                }
                            case SqlCeLib.ExecMode.NonQuery:
                                {
                                    obj = commandText.ExecuteNonQuery();
                                    return obj;
                                }
                            case SqlCeLib.ExecMode.Query:
                                {
                                    DataTable dataTable = new DataTable();
                                    SqlCeDataAdapter sqlCeDataAdapter = new SqlCeDataAdapter(commandText);
                                    try
                                    {
                                        sqlCeDataAdapter.Fill(dataTable);
                                    }
                                    finally
                                    {
                                        if (sqlCeDataAdapter != null)
                                        {
                                            sqlCeDataAdapter.Dispose();
                                        }
                                    }
                                    obj = dataTable;
                                    return obj;
                                }
                        }
                        obj = null;
                    }
                    finally
                    {
                        if (commandText != null)
                        {
                            commandText.Dispose();
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
                SqlCeLib.Connection(SqlCeLib.ConnStatus.Close);
            }
            return obj;
        }

        public static void Transaction(SqlCeLib.TransStatus Status)
        {
            try
            {
                switch (Status)
                {
                    case SqlCeLib.TransStatus.Begin:
                        {
                            SqlCeLib.Connection(SqlCeLib.ConnStatus.Open);
                            SqlCeLib.sqlCeTrans = SqlCeLib.sqlCeConn.BeginTransaction();
                            break;
                        }
                    case SqlCeLib.TransStatus.Commit:
                        {
                            if (SqlCeLib.sqlCeTrans != null)
                            {
                                SqlCeLib.sqlCeTrans.Commit();
                                SqlCeLib.sqlCeTrans = null;
                            }
                            SqlCeLib.Connection(SqlCeLib.ConnStatus.Close);
                            break;
                        }
                    case SqlCeLib.TransStatus.Rollback:
                        {
                            if (SqlCeLib.sqlCeTrans != null)
                            {
                                SqlCeLib.sqlCeTrans.Rollback();
                                SqlCeLib.sqlCeTrans = null;
                            }
                            SqlCeLib.Connection(SqlCeLib.ConnStatus.Close);
                            break;
                        }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public enum ConnStatus
        {
            Open,
            Close
        }

        public enum ExecMode
        {
            Scalar,
            NonQuery,
            Query
        }

        public enum TransStatus
        {
            Begin,
            Commit,
            Rollback
        }
    }
}