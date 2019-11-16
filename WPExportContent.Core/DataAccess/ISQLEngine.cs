using System.Collections.Generic;
using System.Data;

namespace WPExportContent.Core.DataAccess
{
    public interface ISQLEngine
    {
        void CloseConnection();
        IDbConnection DBConnection(bool open = true);
        IEnumerable<T> Select<T>(string sql);
    }
}