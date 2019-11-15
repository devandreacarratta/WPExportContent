using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using WPExportContent.Core.Plugin;
using WPExportContent.WebUI.DTO;
using WPExportContent.WebUI.Models;

namespace WPExportContent.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            WPToJsonDTOModel model = new WPToJsonDTOModel();
            model.ListOfPluginGroup = new List<ListOfPlugin>();
            foreach (ListOfPlugin p in Enum.GetValues(typeof(ListOfPlugin)))
            {
                model.ListOfPluginGroup.Add(p);
            }

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ExportToJson(WPToJsonDTO value)
        {
            WPExportContentEngine engine = new WPExportContentEngine(value);
            var json = engine.DoWork();

            byte[] jsonBytes = Encoding.ASCII.GetBytes(json);

            StringBuilder sb = new StringBuilder();
            sb.Append("WPExportToJson_");
            sb.Append($"{value.WPSourceDBName}");
            sb.Append("_");
            sb.Append($"{DateTime.UtcNow.ToString("yyyyMMddHHmm")}");
            if (value.JSONIndented==false) 
{
                sb.Append(".min");
            }
            sb.Append(".json");

            Stream stream = new MemoryStream(jsonBytes);
            return File(stream, "application/json", sb.ToString());
        }
    }
}
