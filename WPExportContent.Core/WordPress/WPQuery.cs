namespace WPExportContent.Core.WordPress
{
    public class WPQuery
    {
        private string _tablePrefix = "";
        public WPQuery(string tablePrefix)
        {
            _tablePrefix = tablePrefix;
        }

        public string GetWPPosts
        {
            get
            {
                string result = $@"SELECT * FROM {_tablePrefix}posts WHERE post_status ='publish' AND post_type= 'post'";

                return result;
            }
        }

        public string GetWPProducts
        {
            get
            {
                string result = $@"SELECT * FROM {_tablePrefix}posts WHERE post_status ='publish' AND post_type= 'product'";

                return result;
            }
        }

        public string GetWPUsers
        {
            get
            {
                string result = $@"SELECT * FROM {_tablePrefix}users";
                return result;
            }
        }

        public string GetWPTags
        {
            get
            {
                string result = $@" SELECT 
                        T.term_id, 
                        T.name, 
                        T.slug, 
                        R.object_id 
                    FROM  {_tablePrefix}terms T 
                        INNER JOIN  {_tablePrefix}term_relationships R 
                            ON T.term_id = R.term_taxonomy_id 
                        INNER JOIN  {_tablePrefix}term_taxonomy TT 
                            ON TT.term_id = T.term_id 
                    WHERE TT.taxonomy IN( 'post_tag' , 'product_tag') ";

                return result;
            }
        }

        public string GetWPCategories
        {
            get
            {
                string result = $@" SELECT 
                        T.term_id, 
                        T.name, 
                        T.slug, 
                        R.object_id 
                    FROM  {_tablePrefix}terms T 
                        INNER JOIN  {_tablePrefix}term_relationships R 
                            ON T.term_id = R.term_taxonomy_id 
                        INNER JOIN  {_tablePrefix}term_taxonomy TT 
                            ON TT.term_id = T.term_id 
                    WHERE TT.taxonomy IN( 'category' , 'product_cat') ";

                return result;
            }
        }

    }
}
