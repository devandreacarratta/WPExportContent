using WPExportContent.Core.DataAccess;
using WPExportContent.Core.DTO;
using WPExportContent.Core.Export;
using WPExportContent.Core.WordPress;

namespace WPExportContent
{

    public class WPExportContentEngine
    {
        private WPQuery _wpQuery = null;
        private WPConfigurationSourceDTO _wpSource = null;
        private WPConfigurationOUTFileDTO _configurationOUTFile = null;
        private WPConfigurationPluginExportDTO _wpConfigurationPluginExportDTO = null;

        public WPExportContentEngine()
        {
            _wpSource = Configuration.GetWPSourceDTO();
            _wpQuery = new WPQuery(_wpSource.TABLE_PREFIX);
            _configurationOUTFile = Configuration.GetOUTFileDTO();
            _wpConfigurationPluginExportDTO = Configuration.GetPluginExportDTO();
        }

        public void DoWork()
        {
            MySQLEngine mySQLEngine = new MySQLEngine(
                _wpSource.DB_HOST,
                _wpSource.DB_NAME,
                _wpSource.DB_USER,
                _wpSource.DB_PASSWORD
            );

            WPExportDTO exportDTO = new WPExportDTO();
            exportDTO.WPPosts = mySQLEngine.Select<WPPostDTO>(_wpQuery.GetWPPosts);
            exportDTO.WPPostChildren = mySQLEngine.Select<WPPostDTO>(_wpQuery.GetWPPostChildren);
            exportDTO.WPTags = mySQLEngine.Select<WPTagDTO>(_wpQuery.GetWPTags);
            exportDTO.WPCategories = mySQLEngine.Select<WPCategoryDTO>(_wpQuery.GetWPCategories);
            exportDTO.WPUsers = mySQLEngine.Select<WPUserDTO>(_wpQuery.GetWPUsers);
            exportDTO.WPPostsMeta = mySQLEngine.Select<WPPostMetaDTO>(_wpQuery.GetWPPostMeta);

            if (_wpConfigurationPluginExportDTO.WooCommerce)
            {
                exportDTO.WPProducts = mySQLEngine.Select<WPProductDTO>(_wpQuery.GetWPProducts);
                exportDTO.WPProductChildren = mySQLEngine.Select<WPProductDTO>(_wpQuery.GetWPProductChildren);
            }


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