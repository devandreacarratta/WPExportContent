using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WPExportContent.Core.DataAccess;
using WPExportContent.Core.DataAccess.Queries;
using WPExportContent.Core.DTO.Output;
using WPExportContent.Core.WordPress;

namespace WPExportContent.Core.Export
{

    public class ExportToDatabase
    {

        private ISQLEngine _engine = null;
        private IDbConnection _dbConnection;

        public ExportToDatabase(ISQLEngine engine)
        {
            _engine = engine;
            _dbConnection = _engine.DBConnection() ;
        }

        public async Task<SortedDictionary<ExportTable, long>> Run(WPExportResult wp)
        {
            SortedDictionary<ExportTable, long> result = new SortedDictionary<ExportTable, long>();

            using (var conn = this._dbConnection)
            {
                long categories = await this.SaveCategoriesAsync(conn, wp.Categories);
                long post = await this.SavePostAsync(conn, wp.Posts);
                long contentCategories = await this.SaveContentCategoriesAsync(conn, wp.ContentCategories);
                long contentTags = await this.SaveContentTagsAsync(conn, wp.ContentTags);
                long products = await this.SaveProductsAsync(conn, wp.Products);
                long tags = await this.SaveTagsAsync(conn, wp.Tags);
                long users = await this.SaveUsersAsync(conn, wp.Users);
                long seos = await this.SaveSeoMetaAsync(conn, wp.SeoMeta);

                result.Add(ExportTable.Categories, categories);
                result.Add(ExportTable.Post, post);
                result.Add(ExportTable.ContentCategories, contentCategories);
                result.Add(ExportTable.ContentTags, contentTags);
                result.Add(ExportTable.Products, products);
                result.Add(ExportTable.Tags, tags);
                result.Add(ExportTable.Users, users);
                result.Add(ExportTable.SeoMeta, seos);
            }

            return result;
        }

        private async Task<long> SaveCategoriesAsync(IDbConnection conn, IEnumerable<CategoryDTO> categories)
        {

            long result = 0;

            foreach (var item in categories)
            {
                result += await conn.ExecuteAsync(ContentQuery.INSERT_CATEGORIES, item);
            }

            return result;
        }

        private async Task<long> SaveContentCategoriesAsync(IDbConnection conn, IEnumerable<ContentCategoriesDTO> contentCategories)
        {

            long result = 0;



            foreach (var item in contentCategories)
            {
                result += await conn.ExecuteAsync(ContentQuery.INSERT_CONTENT_CATEGORIES, item);
            }

            return result;
        }

        private async Task<long> SaveContentTagsAsync(IDbConnection conn, IEnumerable<ContentTagsDTO> contentTags)
        {

            long result = 0;

            foreach (var item in contentTags)
            {
                result += await conn.ExecuteAsync(ContentQuery.INSERT_CONTENT_TAGS, item);
            }

            return result;
        }

        private async Task<long> SaveTagsAsync(IDbConnection conn, IEnumerable<TagDTO> tags)
        {

            long result = 0;


            foreach (var item in tags)
            {
                result += await conn.ExecuteAsync(ContentQuery.INSERT_TAGS, item);
            }

            return result;
        }

        private async Task<long> SaveUsersAsync(IDbConnection conn, IEnumerable<UserDTO> users)
        {

            long result = 0;



            foreach (var item in users)
            {
                result += await conn.ExecuteAsync(ContentQuery.INSERT_USERS, item);
            }

            return result;
        }

        private async Task<long> SaveProductsAsync(IDbConnection conn, IEnumerable<ProductDTO> products)
        {

            long result = 0;

            foreach (var item in products)
            {
                result += await conn.ExecuteAsync(ContentQuery.INSERT_PRODUCTS, item);
            }

            return result;
        }

        private async Task<long> SavePostAsync(IDbConnection conn, IEnumerable<PostDTO> posts)
        {

            long result = 0;

            foreach (var item in posts)
            {
                result += await conn.ExecuteAsync(ContentQuery.INSERT_POSTS, item);
            }

            return result;
        }

        public async Task<long> SaveSeoMetaAsync(IDbConnection conn, IEnumerable<SeoDTO> seo)
        {
            long result = 0;

            foreach (var item in seo)
            {
                result += await conn.ExecuteAsync(ContentQuery.INSERT_SEOMETA, item);
            }

            return result;
        }

    }
}