using APIEmpHub.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIEmpHub.Utility.Helper
{
    public class HelperSql
    {
        private string _strConOpen = "Open";
        private string _strConClose = "Close";
        private string _strConError = "Error";
        private string _strTranBegin = "Begin";
        private string _strTranRollback = "Rollback";
        private string _strTranCommit = "Commit";
        private string _strTranError = "Error";

        private SqlConnection _sqlCon;
        private SqlTransaction _sqlTran;

        public SqlCommand sqlCom;
        public string conStatus;
        public string tranStatus;
        public string errorMessage;
        public int commandTimeOut = 0;
        public string connectionString;

        #region SqlConnection
        public void Open(string connectionString)
        {
            this.connectionString = connectionString;
            try
            {
                this._sqlCon = new SqlConnection(this.connectionString);
                this._sqlCon.Open();
                this.conStatus = this._strConOpen;
            }
            catch (Exception ex)
            {
                this.conStatus = this._strConError;
                this.errorMessage = ex.Message;

                throw new Exception(ex.Message);
            }
        }
        public void Close()
        {
            try
            {
                this._sqlCon.Close();
                this.conStatus = this._strConClose;
            }
            catch (Exception ex)
            {
                this.conStatus = this._strConError;
                this.errorMessage = ex.Message;
            }
        }
        #endregion

        #region SqlTran
        public void BeginTran()
        {
            try
            {
                this._sqlTran = this._sqlCon.BeginTransaction();
                this.tranStatus = this._strTranBegin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RollbackTran()
        {
            try
            {
                this._sqlTran.Rollback();
                this.tranStatus = this._strTranRollback;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CommitTran()
        {
            try
            {
                this._sqlTran.Commit();
                this.tranStatus = this._strTranCommit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Method
        public int SqlCom_ExecuteNonQuery(String strQuery, CommandType sqlComType, params SqlParameter[] sqlPara)
        {
            int intResult = 0;

            try
            {
                this.sqlCom = new SqlCommand();
                sqlCom.CommandText = strQuery;
                sqlCom.CommandTimeout = commandTimeOut;
                sqlCom.CommandType = sqlComType;
                sqlCom.Connection = this._sqlCon;
                if (this.tranStatus == this._strTranBegin) { sqlCom.Transaction = this._sqlTran; }
                if (sqlPara != null) { sqlCom.Parameters.AddRange(sqlPara); }
                intResult = sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return intResult;
        }
        public DataTable SqlCom_DataAdapterWithDataTable(String strQuery, CommandType sqlComType, params SqlParameter[] sqlPara)
        {
            DataTable dt = new DataTable();

            try
            {
                this.sqlCom = new SqlCommand();
                sqlCom.CommandText = strQuery;
                sqlCom.CommandTimeout = 0;
                sqlCom.CommandType = sqlComType;
                sqlCom.Connection = this._sqlCon;
                if (this.tranStatus == this._strTranBegin) { sqlCom.Transaction = this._sqlTran; }
                if (sqlPara != null) { sqlCom.Parameters.AddRange(sqlPara); }
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCom);
                sqlDA.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
        public DataSet SqlCom_DataAdapterWithDataSet(String strQuery, CommandType sqlComType, params SqlParameter[] sqlPara)
        {
            DataSet ds = new DataSet();

            try
            {
                this.sqlCom = new SqlCommand();
                sqlCom.CommandText = strQuery;
                sqlCom.CommandTimeout = 0;
                sqlCom.CommandType = sqlComType;
                sqlCom.Connection = this._sqlCon;
                if (this.tranStatus == this._strTranBegin) { sqlCom.Transaction = this._sqlTran; }
                if (sqlPara != null) { sqlCom.Parameters.AddRange(sqlPara); }
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCom);
                sqlDA.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }
        public Object SqlCom_ExecuteScalar(String strQuery, CommandType sqlComType, params SqlParameter[] sqlPara)
        {
            Object sqlObj;

            try
            {
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.CommandText = strQuery;
                sqlCom.CommandTimeout = 0;
                sqlCom.CommandType = sqlComType;
                sqlCom.Connection = this._sqlCon;
                if (this.tranStatus == this._strTranBegin) { sqlCom.Transaction = this._sqlTran; }
                if (sqlPara != null) { sqlCom.Parameters.AddRange(sqlPara); }
                sqlObj = sqlCom.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sqlObj;
        }
        public Boolean SqlBulkCopy(DataTable dt, String strTableName, SqlBulkCopyOptions sqlBulkOptions = SqlBulkCopyOptions.Default)
        {
            Boolean blnResult = false;
            SqlBulkCopy objSqlBulkCopy = null;
            try
            {
                if (this.tranStatus == this._strTranBegin)
                {
                    objSqlBulkCopy = new SqlBulkCopy(this._sqlCon, sqlBulkOptions, this._sqlTran);
                }
                else if (sqlBulkOptions != SqlBulkCopyOptions.Default)
                {
                    objSqlBulkCopy = new SqlBulkCopy(this._sqlCon.ConnectionString, sqlBulkOptions);
                }
                else
                {
                    objSqlBulkCopy = new SqlBulkCopy(this._sqlCon.ConnectionString);
                }

                objSqlBulkCopy.BulkCopyTimeout = this.commandTimeOut;
                objSqlBulkCopy.DestinationTableName = strTableName;
                objSqlBulkCopy.WriteToServer(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnResult;
        }
        #endregion

        #region Option
        public SqlParameter SqlCom_Parameter(String strName, object objValue)
        {
            if ((objValue == null) || (objValue.ToString() == "(Empty)"))
                return new SqlParameter(strName, DBNull.Value);
            return new SqlParameter(strName, objValue);
        }
        public SqlParameter SqlCom_Parameter(String strName, SqlDbType sqlType, ParameterDirection direction, String value = "")
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = strName;
            parameter.SqlDbType = sqlType;
            parameter.Direction = direction;
            parameter.Value = value;

            return parameter;
        }
        public SqlParameter SqlCom_Parameter(String strName, SqlDbType sqlType, int sqlSize, ParameterDirection direction, String value = "")
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = strName;
            parameter.SqlDbType = sqlType;
            parameter.Size = sqlSize;
            parameter.Direction = direction;
            parameter.Value = value;

            return parameter;
        }
        public String GetQueryCreateTable(DataTable dt, String strTableName, String strPathFile = "", Boolean blnAddUserName = false, Boolean blnAddComputerName = false)
        {
            String strFormat = "";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                strFormat += !String.IsNullOrEmpty(strFormat) ? ", " : "";
                strFormat += String.Format("[{0}] nvarchar(1000)", dt.Columns[i].ColumnName);
            }
            if (!String.IsNullOrEmpty(strPathFile))
            {
                strFormat += !String.IsNullOrEmpty(strFormat) ? ", " : "";
                strFormat += String.Format("[ImportFile] nvarchar(1000) default'{0}'", strPathFile);
            }
            if (blnAddUserName == true)
            {
                strFormat += !String.IsNullOrEmpty(strFormat) ? ", " : "";
                strFormat += String.Format("[UserName] nvarchar(1000) default'{0}'", Environment.UserName);
            }
            if (blnAddComputerName == true)
            {
                strFormat += !String.IsNullOrEmpty(strFormat) ? ", " : "";
                strFormat += String.Format("[ComputerName] nvarchar(1000) default'{0}'", Environment.MachineName);
            }
            return String.Format("if OBJECT_ID('tempdb..{0}') IS NOT NULL begin drop table [{0}] end create table {0}({1})", strTableName, strFormat);
        }

        #endregion
    }
}
