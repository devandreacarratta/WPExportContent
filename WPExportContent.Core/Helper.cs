namespace WPExportContent.Core
{
    public class Helper
    {

        public static string GetMySQLConnectionString(string server, string database, string uid, string pwd)
        {
            return $"Server={server};Database={database};Uid={uid};Pwd={pwd};";
        }

    }
}