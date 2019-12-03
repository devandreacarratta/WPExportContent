using WPExportContent.Core.DataAccess;
using WPExportContent.Core.DTO;

namespace WPExportContent.Core.WordPress
{
    public class WPExportEngine
    {
        public static WPExportDTO RunAllQueries(
                   WPConfigurationSourceDTO configurationSource,
                   WPConfigurationPluginExportDTO configurationPlugin)
        {

            MySQLEngine engine = new MySQLEngine(
                configurationSource.DB_HOST,
                configurationSource.DB_NAME,
                configurationSource.DB_USER,
                configurationSource.DB_PASSWORD
            );

            WPQuery queries = new WPQuery(configurationSource.TABLE_PREFIX);

            WPExportDTO result = new WPExportDTO();

            result.WPPosts = engine.Select<WPPostDTO>(queries.GetWPPosts);
            result.WPPostChildren = engine.Select<WPPostDTO>(queries.GetWPPostChildren);
            result.WPTags = engine.Select<WPTagDTO>(queries.GetWPTags);
            result.WPCategories = engine.Select<WPCategoryDTO>(queries.GetWPCategories);
            result.WPUsers = engine.Select<WPUserDTO>(queries.GetWPUsers);
            result.WPPostsMeta = engine.Select<WPPostMetaDTO>(queries.GetWPPostMeta);

            if (configurationPlugin.WooCommerce)
            {
                result.WPProducts = engine.Select<WPProductDTO>(queries.GetWPProducts);
                result.WPProductChildren = engine.Select<WPProductDTO>(queries.GetWPProductChildren);
            }

            return result;
        }

    }
}
