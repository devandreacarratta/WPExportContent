using Microsoft.AspNetCore.Http;

namespace WPExportContent.WebUI.Models
{
    public class BaseImportDTO
    {
        public string ConnectionString { get; set; }

        public IFormFile contents { get; set; }

        public string Results { get; set; }
    }
}