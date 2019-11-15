using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPExportContent.WebUI.DTO
{
    public interface IWPToJsonDTO
    {
        string PluginExport { get; set; }
        string WPSourceDBHost { get; set; }
        string WPSourceDBName { get; set; }
        string WPSourceDBPassword { get; set; }
        string WPSourceDBTablePrefix { get; set; }
        string WPSourceDBUser { get; set; }
        bool JSONIndented { get; set; }

    }

    public class WPToJsonDTO : IWPToJsonDTO
    {

        public string PluginExport { get; set; }
        public string WPSourceDBName { get; set; }
        public string WPSourceDBUser { get; set; }
        public string WPSourceDBPassword { get; set; } 
        public string WPSourceDBHost { get; set; } 
        public string WPSourceDBTablePrefix { get; set; }
        public bool JSONIndented { get; set; }

    }
}
