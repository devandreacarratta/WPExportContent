using WPExportContent.Core.DTO;
using WPExportContent.Core.Export;
using WPExportContent.Core.WordPress;

namespace WPExportContent
{

    public class WPExportContentEngine
    {

        private WPConfigurationSourceDTO _wpSource = null;
        private WPConfigurationOUTFileDTO _configurationOUTFile = null;
        private WPConfigurationPluginExportDTO _wpConfigurationPluginExportDTO = null;

        public WPExportContentEngine()
        {
            _wpSource = Configuration.GetWPSourceDTO();
            _configurationOUTFile = Configuration.GetOUTFileDTO();
            _wpConfigurationPluginExportDTO = Configuration.GetPluginExportDTO();
        }

        public void DoWork()
        {
            WPExportDTO exportDTO = WPExportEngine.RunAllQueries(
                _wpSource,
                _wpConfigurationPluginExportDTO);

            string json = string.Empty;

            if (string.IsNullOrEmpty(_configurationOUTFile.DirtyExportFile) == false)
            {
                DirtyWPToJson dirtyWPToJson = new DirtyWPToJson(exportDTO);
                json = dirtyWPToJson.CreateJSON(Newtonsoft.Json.Formatting.None);
                FileHelper.WriteToFile(_configurationOUTFile.DirtyExportFile, json);
            }

            WPToJson wPToJson = new WPToJson(exportDTO)
            {
                ExportSeoWithYoast = _wpConfigurationPluginExportDTO.Yoast
            };

            json = wPToJson.CreateJSON(Newtonsoft.Json.Formatting.Indented);

            if (string.IsNullOrEmpty(_configurationOUTFile.ExportFile) == false)
            {
                FileHelper.WriteToFile(_configurationOUTFile.ExportFile, json);
            }

            if (string.IsNullOrEmpty(_configurationOUTFile.SQLServerConnection) == false)
            {
                ExportToSQLServer export = new ExportToSQLServer(_configurationOUTFile.SQLServerConnection);
                WPExportResult wp = Newtonsoft.Json.JsonConvert.DeserializeObject<WPExportResult>(json);
                var result = export.Run(wp).Result;
            }
        }

    }
}