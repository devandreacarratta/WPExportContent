﻿using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WPExportContent.Core.DataAccess
{
    public class SQLServerEngine : ISQLEngine
    {
        private string _connectionString = string.Empty;
        private IDbConnection _dbConnection = null;

        public SQLServerEngine(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection DBConnection(bool open = true)
        {
            if (_dbConnection == null)
            {   
                   _dbConnection = new SqlConnection(this._connectionString);
            }

            if (open && _dbConnection.State == ConnectionState.Closed)
            {
                _dbConnection.Open();
            }

            return _dbConnection;
        }

        public void CloseConnection()
        {
            if (_dbConnection != null && _dbConnection.State != ConnectionState.Closed)
            {
                _dbConnection.Close();
            }
        }

        public IEnumerable<T> Select<T>(string sql)
        {

            using (var conn = this.DBConnection())
            {
                var result = conn.Query<T>(sql);
                conn.Close();
                return result as IEnumerable<T>;
            }

        }


    }
}