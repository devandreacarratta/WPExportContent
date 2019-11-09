using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using WPExportContent.Core.DTO;
using Dapper;

namespace WPExportContent.Core.DataAccess
{
    public class MySQLEngine
    {
        private string _connectionString = string.Empty;
        private IDbConnection _dbConnection = null;

        public MySQLEngine(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySQLEngine(string server, string database, string uid, string pwd)
        {
            _connectionString = Helper.GetMySQLConnectionString(server, database, uid, pwd);
        }

        public IDbConnection DBConnection(bool open = true)
        {
            if (_dbConnection == null)
            {
                _dbConnection = new MySqlConnection(this._connectionString);
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

        //public IEnumerable<WPTagDTO> GetWPTags(string sql)
        //{

        //    using (var conn = this.DBConnection())
        //    {
        //        var result = conn.Query<WPTagDTO>(sql);
        //        conn.Close();
        //        return result;
        //    }

        //}

    }
}