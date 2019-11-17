using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WPExportContent.Core.DataAccess;
using WPExportContent.Core.DataAccess.Queries;
using WPExportContent.Core.DTO.Output;
using WPExportContent.Core.WordPress;

namespace WPExportContent.Core.Export
{

    public enum ExportToSQLServerTable
    {
        Categories,
        ContentCategories,
        ContentTags,
        Post,
        Products,
        SeoMeta,
        Tags,
        Users,
    }

    public class ExportToSQLServer
    {

        private string _connection = null;
        private SQLServerEngine _sqlEngine = null;

        private SqlConnection _sqlConnection;

        public ExportToSQLServer(string connection)
        {
            _connection = connection;
            _sqlEngine = new SQLServerEngine(connection);
            _sqlConnection = _sqlEngine.DBConnection() as SqlConnection;
        }

        public async Task<SortedDictionary<ExportToSQLServerTable, long>> Run(WPExportResult wp)
        {
            SortedDictionary<ExportToSQLServerTable, long> result = new SortedDictionary<ExportToSQLServerTable, long>();

            using (var conn = this._sqlConnection)
            {
                long categories = await this.SaveCategoriesAsync(conn, wp.Categories);
                long post = await this.SavePostAsync(conn, wp.Posts);
                long contentCategories = await this.SaveContentCategoriesAsync(conn, wp.ContentCategories);
                long contentTags = await this.SaveContentTagsAsync(conn, wp.ContentTags);
                long products = await this.SaveProductsAsync(conn, wp.Products);
                long tags = await this.SaveTagsAsync(conn, wp.Tags);
                long users = await this.SaveUsersAsync(conn, wp.Users);
                long seos = await this.SaveSeoMetaAsync(conn, wp.SeoMeta);

                result.Add(ExportToSQLServerTable.Categories, categories);
                result.Add(ExportToSQLServerTable.Post, post);
                result.Add(ExportToSQLServerTable.ContentCategories, contentCategories);
                result.Add(ExportToSQLServerTable.ContentTags, contentTags);
                result.Add(ExportToSQLServerTable.Products, products);
                result.Add(ExportToSQLServerTable.Tags, tags);
                result.Add(ExportToSQLServerTable.Users, users);
                result.Add(ExportToSQLServerTable.SeoMeta, seos);
            }

            return result;
        }

        private async Task<long> SaveCategoriesAsync(SqlConnection conn, IEnumerable<CategoryDTO> categories)
        {

            long result = 0;

            foreach (var item in categories)
            {
                result += await conn.ExecuteAsync(SQLServerQuery.INSERT_CATEGORIES, item);
            }

            return result;
        }

        private async Task<long> SaveContentCategoriesAsync(SqlConnection conn, IEnumerable<ContentCategoriesDTO> contentCategories)
        {

            long result = 0;



            foreach (var item in contentCategories)
            {
                result += await conn.ExecuteAsync(SQLServerQuery.INSERT_CONTENT_CATEGORIES, item);
            }

            return result;
        }

        private async Task<long> SaveContentTagsAsync(SqlConnection conn, IEnumerable<ContentTagsDTO> contentTags)
        {

            long result = 0;

            //    string query = @"DELETE FROM [dbo].[ContentTags] WHERE [RowID] = @RowID;
            //          INSERT INTO[dbo].[ContentTags]
            //([RowID]
            //          ,[RowCreationDateUTC]
            //          ,[IDContent]
            //          ,[IDTag])
            //    VALUES
            //          (@RowID
            //          , @RowCreationDateUTC
            //          , @IDContent
            //          , @IDTag)";


            foreach (var item in contentTags)
            {
                result += await conn.ExecuteAsync(SQLServerQuery.INSERT_CONTENT_TAGS, item);
            }

            return result;
        }

        private async Task<long> SaveTagsAsync(SqlConnection conn, IEnumerable<TagDTO> tags)
        {

            long result = 0;


            foreach (var item in tags)
            {
                result += await conn.ExecuteAsync(SQLServerQuery.INSERT_TAGS, item);
            }

            return result;
        }

        private async Task<long> SaveUsersAsync(SqlConnection conn, IEnumerable<UserDTO> users)
        {

            long result = 0;



            foreach (var item in users)
            {
                result += await conn.ExecuteAsync(SQLServerQuery.INSERT_USERS, item);
            }

            return result;
        }

        private async Task<long> SaveProductsAsync(SqlConnection conn, IEnumerable<ProductDTO> products)
        {

            long result = 0;

            foreach (var item in products)
            {
                result += await conn.ExecuteAsync(SQLServerQuery.INSERT_PRODUCTS, item);
            }

            return result;
        }

        private async Task<long> SavePostAsync(SqlConnection conn, IEnumerable<PostDTO> posts)
        {

            long result = 0;

            foreach (var item in posts)
            {
                result += await conn.ExecuteAsync(SQLServerQuery.INSERT_POSTS, item);
            }

            return result;
        }

        public async Task<long> SaveSeoMetaAsync(SqlConnection conn, IEnumerable<SeoDTO> seo)
        {
            long result = 0;

            foreach (var item in seo)
            {
                result += await conn.ExecuteAsync(SQLServerQuery.INSERT_SEOMETA, item);
            }

            return result;
        }

    }
}