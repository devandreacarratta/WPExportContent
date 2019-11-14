using Microsoft.Extensions.Configuration;
using WPExportContent.Core.DTO;

namespace WPExportContent
{
    public class Configuration
    {

        private static IConfigurationRoot _configurationRoot = null;
        private static IConfigurationRoot ConfigurationRoot
        {
            get
            {
                if (_configurationRoot == null)
                {

                    var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json");

                    _configurationRoot = builder.Build();
                }
                return _configurationRoot;
            }
        }


        public static WPConfigurationSourceDTO GetWPSourceDTO()
        {
            WPConfigurationSourceDTO result = ConfigurationRoot.GetSection("WPSource").Get<WPConfigurationSourceDTO>();
            return result;
        }

        public static WPConfigurationOUTFileDTO GetOUTFileDTO()
        {
            WPConfigurationOUTFileDTO result = ConfigurationRoot.GetSection("OUTFile").Get<WPConfigurationOUTFileDTO>();
            return result;
        }

        public static WPConfigurationPluginExportDTO GetPluginExportDTO()
        {
            WPConfigurationPluginExportDTO result = ConfigurationRoot.GetSection("PluginExport").Get<WPConfigurationPluginExportDTO>();
            return result;
        }

    }
}