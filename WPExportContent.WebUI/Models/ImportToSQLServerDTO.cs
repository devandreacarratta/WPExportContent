using Microsoft.AspNetCore.Http;

namespace WPExportContent.WebUI.Models
{
    public class ImportToSQLServerDTO
    {

        public string SQLConnectionString { get; set; }

        public IFormFile contents { get; set; }


    }
}
