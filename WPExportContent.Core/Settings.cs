using System;
using System.Collections.Generic;
using System.Text;

namespace WPExportContent.Core
{
    public class Settings
    {

        public class PostMeta
        {
            public class Yoast
            {
                public const string FOCUS_KW = "_yoast_wpseo_focuskw";
                public const string META_DESC = "_yoast_wpseo_metadesc";
            }
        }

        public class Posts
        {
            public class PostType
            {
                public const string POST = "post";
                public const string PRODUCT = "product";
            }
        }

        public class TermTaxonomy
        {
            public class Taxonomy
            {
                public const string POST_TAG = "post_tag";
                public const string PRODUCT_TAG = "product_tag";
            }
        }
    }
}
