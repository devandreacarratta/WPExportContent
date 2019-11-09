using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

        public WPExportContentEngine()
        {
            _wpSource = Configuration.GetWPSourceDTO();
            _wpQuery = new WPQuery(_wpSource.TABLE_PREFIX);
            _configurationOUTFile = Configuration.GetOUTFileDTO();
        }

        public void DoWork()
        {


            MySQLEngine mySQLEngine = new MySQLEngine(
                _wpSource.DB_HOST,
                _wpSource.DB_NAME,
                _wpSource.DB_USER,
                _wpSource.DB_PASSWORD
            );

            var posts = mySQLEngine.Select<WPPostDTO>(_wpQuery.GetWPPosts);
            var tags = mySQLEngine.Select<WPTagDTO>(_wpQuery.GetWPTags);
            var category = mySQLEngine.Select<WPCategoryDTO>(_wpQuery.GetWPCategories);

            DirtyWPToJson dirtyWPToJson = new DirtyWPToJson()
            {
                Categories = category,
                Tags = tags,
                Posts = posts
            };
            dirtyWPToJson.Run(_configurationOUTFile.DirtyExportFile);



        }

       
    }
}