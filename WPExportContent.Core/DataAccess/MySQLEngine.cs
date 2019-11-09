using MySql.Data.MySqlClient;
using System.Data;

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

    }
}