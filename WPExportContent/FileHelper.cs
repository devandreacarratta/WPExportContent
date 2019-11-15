using System.IO;

namespace WPExportContent
{
    public static class FileHelper
    {

        public static void WriteToFile(string fileName, string content)
        {
            File.Delete(fileName);
            File.WriteAllText(fileName, content);
        }

    }
}