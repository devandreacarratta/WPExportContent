﻿using WPExportContent.Core.DataAccess;
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
            var products = mySQLEngine.Select<WPProductDTO>(_wpQuery.GetWPProducts);
            var tags = mySQLEngine.Select<WPTagDTO>(_wpQuery.GetWPTags);
            var category = mySQLEngine.Select<WPCategoryDTO>(_wpQuery.GetWPCategories);
            var users = mySQLEngine.Select<WPUserDTO>(_wpQuery.GetWPUsers);

            DirtyWPToJson dirtyWPToJson = new DirtyWPToJson()
            {
                Categories = category,
                Tags = tags,
                Posts = posts,
                Products = products,
                Users = users
            };
            dirtyWPToJson.Run(_configurationOUTFile.DirtyExportFile);

            WPToJson wPToJson = new WPToJson()
            {
                Categories = category,
                Tags = tags,
                Posts = posts,
                Products = products,
                Users = users
            };
            wPToJson.Run(_configurationOUTFile.ExportFile);

        }


    }
}