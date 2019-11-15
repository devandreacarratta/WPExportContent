using System;
using System.Collections.Generic;
using WPExportContent.Core.Plugin;
using WPExportContent.WebUI.DTO;

namespace WPExportContent.WebUI.Models
{
    public class WPToJsonDTOModel : WPToJsonDTO
    {

        public WPToJsonDTOModel()
        {
            ListOfPluginGroup = new List<ListOfPlugin>();
            foreach (var item in Enum.GetValues(typeof(ListOfPlugin)))
            {
                ListOfPluginGroup.Add((ListOfPlugin)item);
            }
        }

        public List<ListOfPlugin> ListOfPluginGroup { get; set; }

    }
}
