using System;

namespace WPExportContent.Core.DTO
{
    public class WPTablePostsDTO
    {

        public long ID { get; set; }
        public long post_author { get; set; }
        public DateTime post_date { get; set; }
        public DateTime post_date_gmt { get; set; }
        public string post_content { get; set; }
        public string post_title { get; set; }

        public string post_excerpt { get; set; }
        public string post_status { get; set; }
        public string comment_status { get; set; }
        public string ping_status { get; set; }
        public string post_password { get; set; }

        public string post_name { get; set; }
        public string to_ping { get; set; }
        public string pinged { get; set; }
        public DateTime post_modified { get; set; }
        public DateTime post_modified_gmt { get; set; }
        public string post_content_filtered { get; set; }

        public long post_parent { get; set; }
        public string guid { get; set; }
        public int menu_order { get; set; }

        public string post_type { get; set; }
        public string post_mime_type { get; set; }
        public int comment_count { get; set; }

    }
}
