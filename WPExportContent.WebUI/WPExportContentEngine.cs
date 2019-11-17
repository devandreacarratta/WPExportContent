using System;
using WPExportContent.Core.DTO;
using WPExportContent.Core.Export;
using WPExportContent.Core.Plugin;
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

            WPConfigurationSourceDTO configurationSource = new WPConfigurationSourceDTO()
            {
                DB_HOST = this._wpToJsonDTO.WPSourceDBHost,
                DB_NAME = this._wpToJsonDTO.WPSourceDBName,
                DB_PASSWORD = this._wpToJsonDTO.WPSourceDBPassword,
                DB_USER = this._wpToJsonDTO.WPSourceDBUser,
                TABLE_PREFIX = this._wpToJsonDTO.WPSourceDBTablePrefix,
            };

            WPConfigurationPluginExportDTO configurationPluginExport = new WPConfigurationPluginExportDTO()
            {
                WooCommerce = (Array.IndexOf(this._wpToJsonDTO.PluginExport, ListOfPlugin.WooCommerce) != -1),
                Yoast = (Array.IndexOf(this._wpToJsonDTO.PluginExport, ListOfPlugin.Yoast) != -1)
            };


            WPExportDTO exportDTO = WPExportEngine.RunAllQueries(configurationSource, configurationPluginExport);

            Newtonsoft.Json.Formatting formatting = Newtonsoft.Json.Formatting.None;
            if (this._wpToJsonDTO.JSONIndented)
            {
                formatting = Newtonsoft.Json.Formatting.Indented;
            }

            WPToJson wPToJson = new WPToJson(exportDTO) 
            {
                ExportSeoWithYoast = configurationPluginExport.Yoast
            };
            return wPToJson.CreateJSON(formatting);
        }

    }
}
