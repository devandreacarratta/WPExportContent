using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPExportContent.Core.DataAccess;
using WPExportContent.Core.DTO;
using WPExportContent.Core.Export;
using WPExportContent.Core.WordPress;
using WPExportContent.WebUI.DTO;

namespace WPExportContent.WebUI
{
    public class WPExportContentEngine
    {
        private WPQuery _wpQuery = null;

        public WPToJsonDTO _wpToJsonDTO { get; set; }

        public WPExportContentEngine(WPToJsonDTO value)
        {
            _wpToJsonDTO = value;

            _wpQuery = new WPQuery(_wpToJsonDTO.WPSourceDBTablePrefix);
        }

        public string DoWork()
        {
            MySQLEngine mySQLEngine = new MySQLEngine(
                _wpToJsonDTO.WPSourceDBHost,
                _wpToJsonDTO.WPSourceDBName,
                _wpToJsonDTO.WPSourceDBUser,
                _wpToJsonDTO.WPSourceDBPassword
            );

            WPExportDTO exportDTO = new WPExportDTO();

            exportDTO.WPPosts = mySQLEngine.Select<WPPostDTO>(_wpQuery.GetWPPosts);
            exportDTO.WPTags = mySQLEngine.Select<WPTagDTO>(_wpQuery.GetWPTags);
            exportDTO.WPCategories = mySQLEngine.Select<WPCategoryDTO>(_wpQuery.GetWPCategories);
            exportDTO.WPUsers = mySQLEngine.Select<WPUserDTO>(_wpQuery.GetWPUsers);

            if (_wpToJsonDTO.PluginExport.Contains("WooCommerce"))
            {
                exportDTO.WPProducts = mySQLEngine.Select<WPProductDTO>(_wpQuery.GetWPProducts);
            }

            Newtonsoft.Json.Formatting formatting = Newtonsoft.Json.Formatting.None;
            if (this._wpToJsonDTO.JSONIndented)
            {
                formatting = Newtonsoft.Json.Formatting.Indented;
            }

            WPToJson wPToJson = new WPToJson(exportDTO);
            return wPToJson.CreateJSON(formatting);
        }

    }
}
