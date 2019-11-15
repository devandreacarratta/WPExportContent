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
            exportDTO.WPTags = mySQLEngine.Select<WPTagDTO>(_wpQuery.GetWPTags);
            exportDTO.WPCategories = mySQLEngine.Select<WPCategoryDTO>(_wpQuery.GetWPCategories);
            exportDTO.WPUsers = mySQLEngine.Select<WPUserDTO>(_wpQuery.GetWPUsers);

            if (_wpConfigurationPluginExportDTO.WooCommerce)
            {
                exportDTO.WPProducts = mySQLEngine.Select<WPProductDTO>(_wpQuery.GetWPProducts);
            }

            if (string.IsNullOrEmpty(_configurationOUTFile.DirtyExportFile) == false)
            {
                DirtyWPToJson dirtyWPToJson = new DirtyWPToJson(exportDTO);
                string json = dirtyWPToJson.CreateJSON(Newtonsoft.Json.Formatting.None);

                FileHelper.WriteToFile(_configurationOUTFile.DirtyExportFile, json);
            }

            if (string.IsNullOrEmpty(_configurationOUTFile.ExportFile) == false)
            {
                WPToJson wPToJson = new WPToJson(exportDTO);
                string json = wPToJson.CreateJSON(Newtonsoft.Json.Formatting.None);

                FileHelper.WriteToFile(_configurationOUTFile.ExportFile, json);
            }
        }

    }
}