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
                string result = $@"SELECT * FROM {_tablePrefix}posts WHERE post_status ='publish' AND post_type= '{Settings.Posts.PostType.POST}'";

                return result;
            }
        }

        public string GetWPPostChildren
        {
            get
            {
                string result = $@"SELECT P.* 
	                FROM {_tablePrefix}posts AS P
    	                INNER JOIN {_tablePrefix}posts AS PP
        	                ON PP.ID = p.post_parent
                    WHERE 
    	                PP.post_status ='publish' 
                        AND PP.post_type= 'post'";

                return result;
            }
        }

        public string GetWPProducts
        {
            get
            {
                string result = $@"SELECT * FROM {_tablePrefix}posts WHERE post_status ='publish' AND post_type= '{Settings.Posts.PostType.PRODUCT}'";

                return result;
            }
        }

        public string GetWPProductChildren
        {
            get
            {
                string result = $@"SELECT P.* 
	                FROM {_tablePrefix}posts AS P
    	                INNER JOIN {_tablePrefix}posts AS PP
        	                ON PP.ID = p.post_parent
                    WHERE 
    	                PP.post_status ='publish' 
                        AND PP.post_type= 'product'";

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
                    WHERE TT.taxonomy IN( '{Settings.TermTaxonomy.Taxonomy.POST_TAG}' , '{Settings.TermTaxonomy.Taxonomy.PRODUCT_TAG}') ";

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
                    WHERE TT.taxonomy IN( '{Settings.TermTaxonomy.Taxonomy.POST_TAG}' , '{Settings.TermTaxonomy.Taxonomy.PRODUCT_TAG}') ";

                return result;
            }
        }

        public string GetWPPostMeta
        {
            get
            {
                   string result = $@"SELECT PM.* 
                    FROM {_tablePrefix}postmeta AS PM 
                         INNER JOIN {_tablePrefix}posts AS P 
                        ON P.ID = PM.post_id  
                        WHERE P.post_status = 'publish' 
                            AND P.post_type IN('{Settings.Posts.PostType.POST}', '{Settings.Posts.PostType.PRODUCT}')";

                return result;
            }
        }

    }
}
