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


        public static WPSourceDTO GetWPSourceDTO()
        {
            WPSourceDTO result = ConfigurationRoot.GetSection("WPSource").Get<WPSourceDTO>();
            return result;
        }

    }
}