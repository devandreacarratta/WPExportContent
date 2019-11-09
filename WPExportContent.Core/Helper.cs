namespace WPExportContent.Core
{
    public class Helper
    {

        public static string GetMySQLConnectionString(string server, string database, string uid, string pwd,int port = 3306)
        {
            return $"Server={server};Database={database};Uid={uid};Pwd={pwd};Port={port}";
        }

    }
}